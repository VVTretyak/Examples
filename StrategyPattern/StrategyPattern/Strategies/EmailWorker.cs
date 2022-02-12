using StrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategy
{
    class EmailWorker : ISendWorker
    {
        private string msg;
        private string endEmail;

        public EmailWorker(string msg, string endEmail)
        {
            this.msg = msg;
            this.endEmail = endEmail;
        }

        public string Send()
        {
            throw new NotImplementedException();
        }
    }
}
