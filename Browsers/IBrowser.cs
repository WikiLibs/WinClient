using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinClient.Browsers
{
    interface IBrowser
    {
        dynamic Get(NetManager net);
        dynamic Patch(NetManager net, string key, object input);
        dynamic Post(NetManager net, object input);
        bool Delete(NetManager net, string key);
        bool CanPatch(string pname);
        bool CanDelete(string pname);
    }
}
