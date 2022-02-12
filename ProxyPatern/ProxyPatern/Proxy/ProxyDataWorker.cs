using ProxyPatern.Context;
using ProxyPatern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatern.Proxy
{
    class ProxyDataWorker : IProxySQLserver
    {
        private readonly ProxyContext proxyContext;
        private Person person;
        public ProxyDataWorker(ProxyContext proxyContext)
        {
            this.proxyContext = proxyContext;
        }

        public IEnumerable<IModel> getData()
        {          
            using(var dbCon = proxyContext)
            {               
                return dbCon.people.OrderBy(x => x.Id).ToList();
            }            
        }

        public void putData(IModel model)
        {
            this.person = (Person)model;
            using (var dbCon = proxyContext)
            {
                proxyContext.people.Add(person);
                dbCon.SaveChanges();
            }       
        }
    }
}
