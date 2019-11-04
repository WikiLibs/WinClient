using Microsoft.Build.Framework;
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

    class PostBot// : IAction
    {
        public string Method => "POST";

        public string DisplayName => "Create Bot";

        public bool NeedAuth => true;

        public Control CreateInputControl()
        {
            var p = new PropertyMap();

            p.SetPropertyObject(new BotCreate());
            return (p);
        }

        public Control CreateOutputControl()
        {
            return (new JsonTreeViewer());
        }

        public JObject GetInput(Control ctrl)
        {
            var mdl = ((PropertyMap)ctrl).GetPropertyObject<BotCreate>();
            return (JObject.FromObject(new
            {
                name = mdl.Name,
                email = mdl.Email,
                @private = mdl.Private,
                profileMsl = mdl.ProfileMsg,
                pseudo = mdl.Pseudo
            }));
        }

        public string GetURL(Control ctrl)
        {
            return ("bot");
        }

        public void ProcessOutput(Control ctrl, dynamic response, NetManager mgr)
        {
            var t = (JsonTreeViewer)ctrl;
            t.RenderJson((JToken)response);
        }
    }
}
