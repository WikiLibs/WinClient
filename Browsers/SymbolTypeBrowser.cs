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
    class TypeCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }

    class TypeUpdate
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }

    class SymbolTypeBrowser : IBrowser
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
            return (new TypeUpdate());
        }

        public object CreatePostObject()
        {
            return (new TypeCreate());
        }

        public bool Delete(NetManager net, string key)
        {
            return (net.Delete(true, "symbol/type/" + key, out _));
        }

        public dynamic Get(NetManager net)
        {
            net.Get(false, "symbol/type/", out dynamic resp);
            return (resp);
        }

        public dynamic Patch(NetManager net, string key, object input)
        {
            var obj = (TypeUpdate)input;
            net.Patch(true, "symbol/type/" + key, out dynamic resp, JObject.FromObject(new
            {
                name = obj.Name,
                displayName = obj.DisplayName
            }));
            return (resp);
        }

        public dynamic Post(NetManager net, object input)
        {
            var obj = (TypeCreate)input;
            net.Post(true, "symbol/type", out dynamic resp, JObject.FromObject(new
            {
                name = obj.Name,
                displayName = obj.DisplayName
            }));
            return (resp);
        }

        public class Builder : View.IBuilder
        {
            public string DisplayName => "SymbolType Browser";

            public View Build(NetManager mgr)
            {
                return (new BrowserView(mgr, new SymbolTypeBrowser()));
            }
        }
    }
}
