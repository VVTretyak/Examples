using StrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class Sender
    {
        private ISendWorker sendWorker;
        public void SetSendWorker(ISendWorker sendWorker)
        {
            this.sendWorker = sendWorker;
        }

        public string SendData()
        {
            string resulOperation = sendWorker.Send();
            return resulOperation;
        }
    }
}
