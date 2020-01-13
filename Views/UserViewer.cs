using System.Windows.Forms;
using WinClient.UI;

namespace WinClient.Views
{
    class UserViewer : View
    {
        public UserViewer(NetManager mgr) : base(mgr)
        {
        }

        public override Control BuildMainView()
        {
            dynamic root;
            NetManager.Get(true, "/user/me", out root);
            var ui = new JsonTreeViewer();
            ui.RenderJson(root, false);
            return (ui);
        }

        public class Builder : IBuilder
        {
            public string DisplayName => "Current User Viewer";

            public View Build(NetManager mgr)
            {
                return (new UserViewer(mgr));
            }
        }
    }
}
