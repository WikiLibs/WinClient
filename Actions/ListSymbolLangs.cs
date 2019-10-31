using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient.Actions
{
    class ListSymbolLangs : IAction
    {
        public string Method => "GET";

        public string DisplayName => "List Symbol Langs";

        public bool NeedAuth => false;

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
            return ("symbol/lang");
        }

        public void ProcessOutput(Control ctrl, dynamic response, NetManager mgr)
        {
            var t = (JsonTreeViewer)ctrl;
            t.RenderJson((JToken)response);
        }
    }
}
