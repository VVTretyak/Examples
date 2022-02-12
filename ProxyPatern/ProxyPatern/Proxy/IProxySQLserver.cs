using ProxyPatern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatern.Proxy
{
    interface IProxySQLserver
    {
        IEnumerable<IModel> getData();
        void putData(IModel model);
    }
}
