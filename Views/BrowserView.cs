using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinClient.Browsers;

namespace WinClient.Views
{
    class BrowserView : View
    {
        private IBrowser _browser;
        private UI.Browser _ui;
        private object _post;
        private object _patch;
        private string _netkey;

        public BrowserView(NetManager mgr, IBrowser b) : base(mgr)
        {
            _browser = b;
            _post = _browser.CreatePostObject();
        }

        public override Control BuildMainView()
        {
            _ui = new UI.Browser();
            var obj = _browser.Get(NetManager);

            _ui.RunPost.Click += RunPost_Click;
            _ui.RunPatch.Click += RunPatch_Click;
            _ui.OK.Click += OK_Click;
            _ui.OutputPanel.HasDeleteOperation += HasDelete;
            _ui.OutputPanel.HasPatchOperation += HasPatch;
            _ui.OutputPanel.RunDeleteOperation += RunDelete;
            _ui.OutputPanel.RunPatchOperation += RunPatch;
            _ui.OutputPanel.RenderJson(obj);
            _ui.PostPMap.SetPropertyObject(_post);
            return (_ui);
        }

        private void RunPatch_Click(object sender, EventArgs e)
        {
            var obj = _browser.Patch(NetManager, _netkey, _patch);
            _ui.OutputPanel.RenderJson(obj);
            _patch = null;
            _ui.PatchPMap.SetPropertyObject(null);
        }

        private bool HasDelete(string key)
        {
            return (_browser.CanDelete(key));
        }

        private bool HasPatch(string key)
        {
            return (_browser.CanPatch(key));
        }

        private void RunPatch(string key, string value)
        {
            _patch = _browser.CreatePatchObject(key, value);
            _netkey = value;
            _ui.PatchPMap.SetPropertyObject(_patch);
        }

        private void RunDelete(string key, string value)
        {
            _browser.Delete(NetManager, value);
            var obj = _browser.Get(NetManager);
            _ui.OutputPanel.RenderJson(obj);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            var obj = _browser.Get(NetManager);

            _ui.OutputPanel.RenderJson(obj);
        }

        private void RunPost_Click(object sender, EventArgs e)
        {
            var obj = _browser.Post(NetManager, _post);

            _ui.OutputPanel.RenderJson(obj);
            _post = _browser.CreatePostObject();
            _ui.PostPMap.SetPropertyObject(_post);
        }
    }
}
