using SQLite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SQLite
{
    /// <summary>
    /// Считываем и добавляем данные с пощью прямых запросов SQLite
    /// </summary>
    public partial class Form1 : Form
    {
        static SQLiteConnection db;
        private Person personID = new Person();
        static string ConnectionString = @"Data Source=D:\TestSQLite.db";

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var request = @"SELECT ID, Name, NumberPhone FROM Person";
            dataGridView1.DataSource = ShowData(request);
            dataGridView1.Columns[2].Width = 150;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db = new SQLiteConnection(ConnectionString);
            db.Open();
            var person = new Person();
            person.Name = TbNamePerson.Text;
            person.NumberPhone = TbNumberPhone.Text;

            var requestCheck = $"SELECT ID, Name, NumberPhone FROM Person Where  Name='{person.Name}'";
            var cmd = db.CreateCommand();
            cmd.CommandText = requestCheck;
            var checkMark = cmd.ExecuteScalar();
            if (checkMark == null)
            {
                string request = $"INSERT INTO Person (Name, NumberPhone) values('{person.Name}','{person.NumberPhone}')";
                cmd.CommandText = request;
                cmd.ExecuteScalar();
            }
            else
            {
                MessageBox.Show("Такой пользователь уже есть!");
            }
           
            var requestShow = @"SELECT ID, Name, NumberPhone FROM Person";
            dataGridView1.DataSource = ShowData(requestShow);
            db.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var request = @"SELECT ID, Name, NumberPhone FROM Person";
            dataGridView1.DataSource = ShowData(request);
        }

        private static DataTable ShowData(string sqlReq)
        {
            List<Person> people = new List<Person>();
            db = new SQLiteConnection(ConnectionString);
            db.Open();
            SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlReq, db);
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(sQLiteCommand);
            sQLiteDataAdapter.Fill(dataTable);

            //foreach (DataRow item in dataTable.Rows)
            //{
            //    people.Add(new Person
            //    {
            //        ID = Convert.ToInt32(item.ItemArray[0]),
            //        Name = item.ItemArray[1].ToString(),
            //        NumberPhone = item.ItemArray[2].ToString(),
            //    });
            //}
            //var t = people;
            return dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            personID = new Person();
            string[] CurrentLineData = ReadStringDataFromDataGridwiew();
            TbNamePerson.Text = CurrentLineData[1];
            TbNumberPhone.Text = CurrentLineData[2];
            var request = $"SELECT ID, Name, NumberPhone FROM Person WHERE ID={CurrentLineData[0]}";
            var oneRecord = ShowData(request);
            personID.ID = Convert.ToInt32(oneRecord.Rows[0].ItemArray[0]);
            personID.Name = oneRecord.Rows[0].ItemArray[1].ToString();
            personID.NumberPhone = oneRecord.Rows[0].ItemArray[2].ToString();
        }

        private string[] ReadStringDataFromDataGridwiew()
        {
            int n = dataGridView1.CurrentRow.Index;
            string[] CurrentLineData = new string[dataGridView1.ColumnCount];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                CurrentLineData[i] = dataGridView1.Rows[n].Cells[i].Value.ToString();
            }
            return CurrentLineData;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db = new SQLiteConnection(ConnectionString);
            db.Open();
            string request = $"Delete from Person WHERE ID={personID.ID}";
            var cmd = db.CreateCommand();
            cmd.CommandText = request;
            cmd.ExecuteScalar();
            var requestShow = @"SELECT ID, Name, NumberPhone FROM Person";
            dataGridView1.DataSource = ShowData(requestShow);
            db.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            db = new SQLiteConnection(ConnectionString);
            db.Open();
            var person = new Person();
            person.Name = TbNamePerson.Text;
            person.NumberPhone = TbNumberPhone.Text;
            string request = $"UPDATE Person SET Name = '{person.Name}', NumberPhone ='{person.NumberPhone}' WHERE ID={personID.ID}";
            var cmd = db.CreateCommand();
            cmd.CommandText = request;
            cmd.ExecuteNonQuery();
            var requestShow = @"SELECT ID, Name, NumberPhone FROM Person";
            dataGridView1.DataSource = ShowData(requestShow);
            db.Close();
        }
    }
}
