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
    class BotCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? Private { get; set; }
        public string ProfileMsg { get; set; }
        [Required]
        public string Pseudo { get; set; }
    }

    class BotUpdate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? Private { get; set; }
        public string ProfileMsg { get; set; }
        public string Pseudo { get; set; }
        public int? GroupId { get; set; }
    }

    class BotBrowser : IBrowser
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
            return (new BotUpdate());
        }

        public object CreatePostObject()
        {
            return (new BotCreate());
        }

        public bool Delete(NetManager net, string key)
        {
            return (net.Delete(true, "bot/" + key.Substring(1, key.Length - 2), out _));
        }

        public dynamic Get(NetManager net)
        {
            net.Get(true, "bot", out dynamic resp);
            return (resp);
        }

        public dynamic Patch(NetManager net, string key, object input)
        {
            var obj = (BotUpdate)input;
            net.Patch(true, "bot/" + key.Substring(1, key.Length - 2), out dynamic resp, JObject.FromObject(new
            {
                name = obj.Name,
                email = obj.Email,
                @private = obj.Private,
                profileMsg = obj.ProfileMsg,
                pseudo = obj.Pseudo,
                groupId = obj.GroupId
            }));
            return (resp);
        }

        public dynamic Post(NetManager net, object input)
        {
            var obj = (BotCreate)input;
            net.Post(true, "bot", out dynamic resp, JObject.FromObject(new
            {
                name = obj.Name,
                email = obj.Email,
                @private = obj.Private,
                profileMsg = obj.ProfileMsg,
                pseudo = obj.Pseudo
            }));
            return (resp);
        }

        public class Builder : View.IBuilder
        {
            public string DisplayName => "Bot Browser";

            public View Build(NetManager mgr)
            {
                return (new BrowserView(mgr, new BotBrowser()));
            }
        }
    }
}
