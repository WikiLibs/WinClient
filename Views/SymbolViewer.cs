using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinClient.UI;

namespace WinClient.Views
{
    class SymbolViewer : View
    {
        public SymbolViewer(NetManager mgr) : base(mgr)
        {
        }

        public JArray GetLangList()
        {
            dynamic resp;

            if (NetManager.Get(false, "symbol/lang", out resp))
                return ((JArray)resp);
            return (null);
        }

        public JArray GetLibList(int lang)
        {
            dynamic resp;

            if (NetManager.Get(false, "symbol/lang/" + lang, out resp))
                return ((JArray)resp);
            return (null);
        }

        public override Control BuildMainView()
        {
            var root = GetLangList();
            var ui = new JsonTreeViewer();
            foreach (var e in root)
            {
                var sub = GetLibList(e["id"].Value<int>());
                e["libs"] = sub;
            }
            ui.RenderJson(root);
            return (ui);
        }

        public class Builder : IBuilder
        {
            public string DisplayName => "Symbol Viewer";

            public View Build(NetManager mgr)
            {
                return (new SymbolViewer(mgr));
            }
        }
    }
}
