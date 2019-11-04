using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinClient.Browsers;

namespace WinClient.Views
{
    class BrowserView : View
    {
        private IBrowser _browser;
        private UI.Browser _ui;

        public BrowserView(NetManager mgr, IBrowser b) : base(mgr)
        {
        }

        public override Control BuildMainView()
        {
            _ui = new UI.Browser();


            return (_ui);
        }
    }
}
