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
            if (NetManager.Get(false, "symbol/lang", out dynamic resp))
                return ((JArray)resp);
            return (null);
        }

        public JArray GetLibList(int lang, int page, JArray init)
        {
            if (NetManager.Get(false, "symbol/lang/" + lang + "?count=" + Constants.SYMBOL_COUNT + "&page=" + page, out dynamic resp))
            {
                JToken rsp = resp;
                foreach (var e in rsp["data"].Value<JArray>())
                    init.Add(e);
                if (rsp["hasMorePages"].Value<bool>())
                    return (GetLibList(lang, page + 1, init));
            }
            return (init);
        }

        public JArray GetSymbolList(int lib, int page, JArray init)
        {
            if (NetManager.Get(false, "symbol/lib/" + lib + "?count=" + Constants.SYMBOL_COUNT + "&page=" + page, out dynamic resp))
            {
                JToken rsp = resp;
                foreach (var e in rsp["data"].Value<JArray>())
                    init.Add(e);
                if (rsp["hasMorePages"].Value<bool>())
                    return (GetSymbolList(lib, page + 1, init));
            }
            return (init);
        }

        public override Control BuildMainView()
        {
            var root = GetLangList();
            var ui = new JsonTreeViewer();
            foreach (var e in root)
            {
                var sub = GetLibList(e["id"].Value<int>(), 1, new JArray());
                e["libs"] = sub;
                foreach (var e1 in sub)
                {
                    var sub1 = GetSymbolList(e1["id"].Value<int>(), 1, new JArray());
                    e1["symbols"] = sub1;
                }
            }
            ui.RenderJson(root, false);
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
