using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace StrategyPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string source = @"D:\\Test1.docx";

            doc = app.Documents.Open(source);
            doc.Activate();
            string str = System.IO.File.ReadAllText("d:\\test.txt");
            Word.Paragraph paragraph = doc.Content.Paragraphs.Add();
            paragraph.Range.Text = str;
            paragraph.Range.InsertParagraphAfter();
            doc.Close();

        }
    }
}
