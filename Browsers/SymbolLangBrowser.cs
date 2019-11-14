using Microsoft.Build.Framework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinClient.Views;

namespace WinClient.Browsers
{
    class LangCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }

    class LangUpdate
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }

    class SymbolLangBrowser : IBrowser
    {
        public bool CanDelete(string pname)
        {
            return (pname == "id");
        }

        public bool CanPatch(string pname)
        {
            return (pname == "id");
        }

        public object CreatePatchObject(string key, string value)
        {
            return (new LangUpdate());
        }

        public object CreatePostObject()
        {
            return (new LangCreate());
        }

        public bool Delete(NetManager net, string key)
        {
            return (net.Delete(true, "symbol/lang/" + key, out _));
        }

        public dynamic Get(NetManager net)
        {
            net.Get(false, "symbol/lang/", out dynamic resp);
            return (resp);
        }

        public dynamic Patch(NetManager net, string key, object input)
        {
            var obj = (LangUpdate)input;
            net.Patch(true, "symbol/lang/" + key, out dynamic resp, JObject.FromObject(new
            {
                name = obj.Name,
                displayName = obj.DisplayName
            }));
            return (resp);
        }

        public dynamic Post(NetManager net, object input)
        {
            var obj = (LangCreate)input;
            net.Post(true, "symbol/lang", out dynamic resp, JObject.FromObject(new
            {
                name = obj.Name,
                displayName = obj.DisplayName
            }));
            return (resp);
        }

        public class Builder : View.IBuilder
        {
            public string DisplayName => "SymbolLang Browser";

            public View Build(NetManager mgr)
            {
                return (new BrowserView(mgr, new SymbolLangBrowser()));
            }
        }
    }
}
