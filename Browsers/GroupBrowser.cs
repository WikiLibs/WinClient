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
    class GroupCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string[] Permissions { get; set; }
    }

    class GroupUpdate
    {
        public string Name { get; set; }
        public string[] Permissions { get; set; }
    }

    class GroupBrowser : IBrowser
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
            return (new GroupUpdate());
        }

        public object CreatePostObject()
        {
            return (new GroupCreate());
        }

        public bool Delete(NetManager net, string key)
        {
            return (net.Delete(true, "admin/group/" + key, out _));
        }

        public dynamic Get(NetManager net)
        {
            net.Get(true, "admin/group", out dynamic resp);
            return (resp);
        }

        public dynamic Patch(NetManager net, string key, object input)
        {
            var obj = (GroupUpdate)input;
            net.Patch(true, "admin/group/" + key, out dynamic resp, JObject.FromObject(new
            {
                name = obj.Name,
                permissions = obj.Permissions
            }));
            return (resp);
        }

        public dynamic Post(NetManager net, object input)
        {
            var obj = (GroupCreate)input;
            net.Post(true, "admin/group", out dynamic resp, JObject.FromObject(new
            {
                name = obj.Name,
                permissions = obj.Permissions
            }));
            return (resp);
        }

        public class Builder : View.IBuilder
        {
            public string DisplayName => "Group Browser";

            public View Build(NetManager mgr)
            {
                return (new BrowserView(mgr, new GroupBrowser()));
            }
        }
    }
}
