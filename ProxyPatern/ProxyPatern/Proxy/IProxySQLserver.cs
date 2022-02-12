using ProxyPatern.Models;
using System.Collections.Generic;

namespace ProxyPatern.Proxy
{
    interface IProxySQLserver
    {
        IEnumerable<IModel> getData();
        void putData(IModel model);
    }
}
