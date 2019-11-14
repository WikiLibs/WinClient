using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WinClient.UI
{
    public partial class JsonTreeViewer : UserControl
    {
        public delegate bool HasPatchOperation1(string key);
        public delegate bool HasDeleteOperation1(string key);
        public delegate void RunPatchOperation1(string key, string value);
        public delegate void RunDeleteOperation1(string key, string value);

        public HasPatchOperation1 HasPatchOperation { get; set; }
        public HasDeleteOperation1 HasDeleteOperation { get; set; }
        public RunPatchOperation1 RunPatchOperation { get; set; }
        public RunDeleteOperation1 RunDeleteOperation { get; set; }

        public JsonTreeViewer()
        {
            InitializeComponent();
            Font = new Font("Microsoft Sans Serif", 14);
        }

        private TreeNode RenderObject(string pname, JObject obj)
        {
            TreeNode res = new TreeNode(pname + " (Object)");

            foreach (JProperty p in obj.Properties())
                res.Nodes.Add(RenderToken(p.Value, p.Name));
            return (res);
        }

        private TreeNode RenderList(string pname, JArray arr)
        {
            TreeNode res = new TreeNode(pname + " (Array)");

            foreach (JToken v in arr.Children())
                res.Nodes.Add(RenderToken(v, null));
            return (res);
        }

        private TreeNode BuildTreeNode(string name, string val)
        {
            var node = new TreeNode(name == null ? val : (name + ": " + val));

            node.Tag = Tuple.Create(name, val);
            node.ContextMenu = CreateContextMenu(node);
            return (node);
        }

        private ContextMenu CreateContextMenu(TreeNode nd)
        {
            var ctx = new ContextMenu();
            var copyV = new MenuItem("Copy Value");
            var copyN = new MenuItem("Copy Name");

            copyV.Click += CopyV_Click;
            copyN.Click += CopyN_Click;
            copyN.Tag = nd;
            copyV.Tag = nd;
            ctx.MenuItems.Add(copyV);
            ctx.MenuItems.Add(copyN);
            var val = ((Tuple<string, string>)nd.Tag).Item1;
            if (val != null)
            {
                if (HasPatchOperation != null && HasPatchOperation(val))
                {
                    var pop = new MenuItem("Patch");
                    pop.Tag = nd;
                    pop.Click += Pop_Click;
                    ctx.MenuItems.Add(pop);
                }
                if (HasDeleteOperation != null && HasDeleteOperation(val))
                {
                    var dop = new MenuItem("Delete");
                    dop.Tag = nd;
                    dop.Click += Dop_Click;
                    ctx.MenuItems.Add(dop);
                }
            }
            return (ctx);
        }

        private void Dop_Click(object sender, EventArgs e)
        {
            var node = (TreeNode)((MenuItem)sender).Tag;
            var val = ((Tuple<string, string>)node.Tag);

            if (val != null)
                RunDeleteOperation(val.Item1, val.Item2);
        }

        private void Pop_Click(object sender, EventArgs e)
        {
            var node = (TreeNode)((MenuItem)sender).Tag;
            var val = ((Tuple<string, string>)node.Tag);

            if (val != null)
                RunPatchOperation(val.Item1, val.Item2);
        }

        private void CopyN_Click(object sender, EventArgs e)
        {
            var node = (TreeNode)((MenuItem)sender).Tag;
            var val = ((Tuple<string, string>)node.Tag).Item1;

            if (val != null)
                Clipboard.SetText(val);
        }

        private void CopyV_Click(object sender, EventArgs e)
        {
            var node = (TreeNode)((MenuItem)sender).Tag;
            var val = ((Tuple<string, string>)node.Tag).Item2;

            if (val != null)
            {
                if (val.StartsWith("\"") && val.EndsWith("\""))
                    val = val.Substring(1, val.Length - 2);
                Clipboard.SetText(val);
            }
        }

        private TreeNode RenderToken(JToken tok, string pname)
        {
            switch (tok.Type)
            {
                case JTokenType.Object:
                    return (RenderObject(pname, (JObject)tok));
                case JTokenType.Array:
                    return (RenderList(pname, (JArray)tok));
                case JTokenType.String:
                    return (pname == null ? BuildTreeNode(null, tok.ToString()) : BuildTreeNode(pname, "\"" + tok.ToString() + "\""));
                default:
                    return (pname == null ? BuildTreeNode(null, tok.ToString()) : BuildTreeNode(pname, tok.ToString()));
            }
        }

        public void RenderJson(JToken token)
        {
            var topNode = RenderToken(token, "Root");

            TreeView.Nodes.Clear();
            TreeView.Nodes.Add(topNode);
            TreeView.ExpandAll();
        }
    }
}
