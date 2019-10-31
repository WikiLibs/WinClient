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
    class TypeCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }

    class PostSymbolType : IAction
    {
        public string Method => "POST";

        public string DisplayName => "Create Symbol Type";

        public bool NeedAuth => true;

        public Control CreateInputControl()
        {
            var p = new PropertyMap();

            p.SetPropertyObject(new TypeCreate());
            return (p);
        }

        public Control CreateOutputControl()
        {
            return (new JsonTreeViewer());
        }

        public JObject GetInput(Control ctrl)
        {
            var mdl = ((PropertyMap)ctrl).GetPropertyObject<TypeCreate>();
            return (JObject.FromObject(new
            {
                name = mdl.Name,
                displayName = mdl.DisplayName
            }));
        }

        public string GetURL(Control ctrl)
        {
            return ("symbol/type");
        }

        public void ProcessOutput(Control ctrl, dynamic response, NetManager mgr)
        {
            var t = (JsonTreeViewer)ctrl;
            t.RenderJson((JToken)response);
        }
    }
}
