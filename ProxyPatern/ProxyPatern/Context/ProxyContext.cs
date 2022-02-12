using ProxyPatern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatern.Context
{
    class ProxyContext : DbContext
    {
        public DbSet<Person> people { get; set; }
        public ProxyContext() { }
    }
}
