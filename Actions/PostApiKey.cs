using Microsoft.Build.Framework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient.Actions
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

    class PostApiKey : IAction
    {
        public string Method => "POST";

        public string DisplayName => "Create ApiKey";

        public bool NeedAuth => true;

        public Control CreateInputControl()
        {
            var p = new PropertyMap();

            p.SetPropertyObject(new ApiKeyCreate());
            return (p);
        }

        public Control CreateOutputControl()
        {
            return (new JsonTreeViewer());
        }

        public JObject GetInput(Control ctrl)
        {
            var mdl = ((PropertyMap)ctrl).GetPropertyObject<ApiKeyCreate>();
            return (JObject.FromObject(new
            {
                description = mdl.Description,
                flags = mdl.Flags,
                expirationDate = mdl.ExpirationDate,
                useNum = mdl.UseNum
            }));
        }

        public string GetURL(Control ctrl)
        {
            return ("admin/apikey");
        }

        public void ProcessOutput(Control ctrl, dynamic response, NetManager mgr)
        {
            var t = (JsonTreeViewer)ctrl;
            t.RenderJson((JToken)response);
        }
    }
}
