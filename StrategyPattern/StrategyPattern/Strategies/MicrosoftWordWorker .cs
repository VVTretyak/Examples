using StrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategy
{
    class MicrosoftWordWorker : ISendWorker
    {
        private readonly string msgText;
        private readonly string path;
        public MicrosoftWordWorker(string msgText, string path)
        {
            this.msgText = msgText;
            this.path = path;
        }

        public string Send()
        {
            //    Stream stream = new Stream();
            //    using (StreamWriter sw = new StreamWriter(fileName, System.Text.Encoding.Default))
            //    {
            //        sw.Write(textToSave);
            return "0";
           }


        //}
    }
}
