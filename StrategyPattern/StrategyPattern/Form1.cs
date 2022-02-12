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
using StrategyPattern.Strategy;

namespace StrategyPattern
{
    public partial class Form1 : Form
    {
        SaveFileDialog saveFileDialog1;
        Sender MySender;
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1 = new SaveFileDialog();
            MySender = new Sender();           
        }

        private void BtnSaveToWord_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.docx)|*.docx|(*.*)|";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            MySender.SetSendWorker(new MicrosoftWordWorker(richTextBox1.Text, filename));
            MessageBox.Show(MySender.SendData());
        }

        private void BtnSaveToJson_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.json)|*.json|(*.*)|";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            MySender.SetSendWorker(new JsonWorker(richTextBox1.Text, filename));
            MessageBox.Show(MySender.SendData());
        }

        private void BtnSendToEmail_Click(object sender, EventArgs e)
        {
            MySender.SetSendWorker(new EmailWorker(richTextBox1.Text, InputEndEmail.Text));
            MessageBox.Show(MySender.SendData());
        }
    }
}
