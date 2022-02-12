using StrategyPattern.Strategies;

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
