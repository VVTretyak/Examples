using StrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StrategyPattern.Strategy
{
    class JsonWorker : ISendWorker
    {
        private readonly string msgText;
        private readonly string path;

        public JsonWorker(string msgText, string path)
        {
            this.msgText = msgText;
            this.path = path;
        }

        public string Send()
        {
            try
            {
                string json = JsonSerializer.Serialize<string>(msgText);
                File.WriteAllText(path, json);
                return "Text was saved to the json file";
            }
            catch (Exception ex)
            {
                return $"Text was not save to the json file-{ex}";
            }
        }
    }
}
