using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinClient.UI;

namespace WinClient.Actions
{
    class ListGroups// : IAction
    {
        public string Method => "GET";

        public string DisplayName => "List Groups";

        public bool NeedAuth => true;

        public Control CreateInputControl()
        {
            return (null);
        }

        public Control CreateOutputControl()
        {
            return (new JsonTreeViewer());
        }

        public JObject GetInput(Control ctrl)
        {
            return (null);
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
