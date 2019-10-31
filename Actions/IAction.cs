using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient.Actions
{
    interface IAction
    {
        string Method { get; }
        string DisplayName { get; }
        bool NeedAuth { get; }
        string GetURL(Control ctrl);
        void ProcessOutput(Control ctrl, dynamic response, NetManager mgr);
        JObject GetInput(Control ctrl);
        Control CreateInputControl();
        Control CreateOutputControl();
    }
}
