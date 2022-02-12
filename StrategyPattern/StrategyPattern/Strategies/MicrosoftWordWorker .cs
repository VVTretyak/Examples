using Microsoft.Office.Interop.Word;
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
            try
            {
                FileStream fileStream = null;
                Document doc = null;
                Application app = new Application();
                fileStream = File.Create(path); 
                fileStream.Close();
                string source = path;
                doc = app.Documents.Open(source);
                doc.Activate();
                string str = msgText;
                Paragraph paragraph = doc.Content.Paragraphs.Add();
                paragraph.Range.Text = str;
                paragraph.Range.InsertParagraphAfter();
                doc.Close();
                return "The document has been saved";
            }
            catch (Exception ex)
            {
                return $"Error save document - {ex}";
            }
        }       
    }
}
