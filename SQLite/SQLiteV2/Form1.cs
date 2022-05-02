using SQLiteV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteV2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //dbConn = new SQLiteConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var person = new Person();
            person.Name = TbNamePerson.Text;
            person.NumberPhone = TbNumberPhone.Text;
            using (var db = new SQLiteConnection("SQLiteTestV2.db"))
            {
                db.


                //db.Insert(person);
                

            }
        }
    }
}
