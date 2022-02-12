using ProxyPatern.Models;
using ProxyPatern.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyPatern
{
    public partial class Form1 : Form
    {
       static ProxyDataWorker proxyDataWorker;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ShowData();
            dataGridView1.Columns[2].Width = 150;
        }

        private void SaveNewPerson_Click(object sender, EventArgs e)
        {
            proxyDataWorker = new ProxyDataWorker(new Context.ProxyContext());
            Person person = new Person();
            person.Name = NameOfPerson.Text;
            person.PhoneNumber = PersonsPhoneNumber.Text;
            proxyDataWorker.putData(person);
            dataGridView1.DataSource = ShowData();           
        }

        private void UpdateClientData_Click(object sender, EventArgs e)
        {          
            dataGridView1.DataSource = ShowData();                                          
        }

        private static DataTable ShowData()
        {
            proxyDataWorker = new ProxyDataWorker(new Context.ProxyContext());
            var people = (List<Person>)proxyDataWorker.getData();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            for (int i = 0; i < people.Count; i++)
            {
                table.Rows.Add(people[i].Id, people[i].Name, people[i].PhoneNumber);
            };
            return table;
        }
    }

}
