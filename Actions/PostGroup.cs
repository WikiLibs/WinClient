using Microsoft.Build.Framework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient.Actions
{
    class GroupCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string[] Permissions { get; set; }
    }

    class PostGroup : IAction
    {
        public string Method => "POST";

        public string DisplayName => "Create Group";

        public bool NeedAuth => true;

        public Control CreateInputControl()
        {
            var p = new PropertyMap();

            p.SetPropertyObject(new GroupCreate());
            return (p);
        }

        public Control CreateOutputControl()
        {
            return (new JsonTreeViewer());
        }

        public JObject GetInput(Control ctrl)
        {
            var mdl = ((PropertyMap)ctrl).GetPropertyObject<GroupCreate>();
            return (JObject.FromObject(new
            {
                name = mdl.Name,
                permissions = mdl.Permissions
            }));
        }

        public string GetURL(Control ctrl)
        {
            return ("admin/group");
        }

        public void ProcessOutput(Control ctrl, dynamic response, NetManager mgr)
        {
            var t = (JsonTreeViewer)ctrl;
            t.RenderJson((JToken)response);
        }
    }
}
