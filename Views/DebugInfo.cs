using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WinClient.UI;

namespace WinClient.Views
{
    class DebugInfo : View
    {
        public DebugInfo(NetManager mgr) : base(mgr)
        {
        }

        public override Control BuildMainView()
        {
            var j = new JsonTreeViewer();
            dynamic response;

            NetManager.Get(false, "debug", out response);
            j.RenderJson(response);
            return (j);
        }

        public class Builder : IBuilder
        {
            public string DisplayName => "Debug Info";

            public View Build(NetManager mgr)
            {
                return (new DebugInfo(mgr));
            }
        }
    }
}
