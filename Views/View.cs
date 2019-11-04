using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient.Views
{
    abstract class View
    {
        public interface IBuilder
        {
            string DisplayName { get; }
            View Build(NetManager mgr);
        }

        protected NetManager NetManager { get; }

        public View(NetManager mgr)
        {
            NetManager = mgr;
        }

        public abstract Control BuildMainView();
    }
}
