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
    class ApiKeyCreate
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int Flags { get; set; }
        [Required]
        public int UseNum { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
    }

    class ApiKeyUpdate
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int? Flags { get; set; }
        public int? UseNum { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }

    class ApiKeyBrowser : IBrowser
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
            return (new ApiKeyUpdate()
            {
                Id = value.Substring(1, value.Length - 2)
            });
        }

        public object CreatePostObject()
        {
            return (new ApiKeyCreate());
        }

        public bool Delete(NetManager net, string key)
        {
            return (net.Delete(true, "admin/apikey/" + key.Substring(1, key.Length - 2), out _));
        }

        public dynamic Get(NetManager net)
        {
            net.Get(true, "admin/apikey", out dynamic resp);
            return (resp);
        }

        public dynamic Patch(NetManager net, string key, object input)
        {
            var obj = (ApiKeyUpdate)input;
            net.Patch(true, "admin/apikey/" + key.Substring(1, key.Length - 2), out dynamic resp, JObject.FromObject(new
            {
                id = obj.Id,
                description = obj.Description,
                flags = obj.Flags,
                useNum = obj.UseNum,
                expirationDate = obj.ExpirationDate
            }));
            return (resp);
        }

        public dynamic Post(NetManager net, object input)
        {
            var obj = (ApiKeyCreate)input;
            net.Post(true, "admin/apikey", out dynamic resp, JObject.FromObject(new
            {
                description = obj.Description,
                flags = obj.Flags,
                useNum = obj.UseNum,
                expirationDate = obj.ExpirationDate
            }));
            return (resp);
        }

        public class Builder : View.IBuilder
        {
            public string DisplayName => "ApiKey Browser";

            public View Build(NetManager mgr)
            {
                return (new BrowserView(mgr, new ApiKeyBrowser()));
            }
        }
    }
}
