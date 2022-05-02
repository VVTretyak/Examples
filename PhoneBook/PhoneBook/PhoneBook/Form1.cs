using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneBook.Models;
using PhoneBook.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace PhoneBook
{
    public partial class PhoneBook : Form
    {
        private DataTable inventoryTable = new DataTable();
        private ReadFromDb readFromDb;
        private int rowsCounter = 0;
        private int IdPerson = 0;
        public event DataGridViewCellMouseEventHandler CellMouseDown;
        public event DataGridViewCellEventHandler CellContentClick;
        static string patternFirstNameAndSurName = "^[А-Яа-яёЁA-Za-z]+$";//строка содержит только буквы      
        static string patternPhone = "[0-9]{5,12}$";//цифры от 5 до 12 символов
        static string patternEmail = "[a-zA-Z1-9\\-\\._]+@[a-z1-9]+(.[a-z1-9]+){1,}";//Паттерн для эмайла
        string[] patterns = new string[] { patternFirstNameAndSurName, patternPhone, patternEmail };

        public PhoneBook()
        {
            InitializeComponent();
           // dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
           // KeyDown += new KeyEventHandler(Form1_KeyDownEnter);
           // dataGridView1.KeyPress += new KeyPressEventHandler(Form1_KeyDownEnter);
            StripMenuEneble(false);
        }

        private void PhoneBook_MouseClick(object sender, MouseEventArgs e)
        {          
            throw new NotImplementedException();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                StripMenuEneble(true);              
            }
            string[] CurrentLineData = ReadStringDataFromDataGridwiew();
            IdPerson = Convert.ToInt32(CurrentLineData[0]);
            textBoxFirstName.Text = CurrentLineData[1];
            textBoxSurName.Text = CurrentLineData[2];
            textBoxPhone1.Text = CurrentLineData[3];
            textBoxPhone2.Text = CurrentLineData[4];
            textBoxEmail1.Text = CurrentLineData[5];
            textBoxEmail2.Text = CurrentLineData[6];
            btnSaveNewPerson.Text = "UpdateData";
        }

        private void PhoneBook_Load(object sender, EventArgs e)
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {

            }

            dataGridView1.DataSource = CreateTable(inventoryTable);
            rowsCounter = dataGridView1.Rows.Count;
            dataGridView1.Columns[0].Width = 20;
        }

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            if (readFromDb == null)
            {
                readFromDb = new ReadFromDb();
            }
            List<Person> people = await readFromDb.ReadAllStartAsync();
            inventoryTable.Rows.Clear();
            dataGridView1.DataSource = AddPeopleToTable(people, inventoryTable);
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (readFromDb == null)
            {
                readFromDb = new ReadFromDb();
            }
            var person = readFromDb.SearchPersonAllMatches(textBox1.Text);
            dataGridView1.DataSource = AddPeopleToTable(person, inventoryTable);            
        }
        #region DataTable
        static DataTable CreateTable(DataTable inventoryTable)
        {
            if (inventoryTable.Columns.Count == 0)
            {
                var Id = new DataColumn("Id", typeof(int));
                var firstName = new DataColumn("FirstName", typeof(string));
                var surName = new DataColumn("SurName", typeof(string));
                var phoneNumber1 = new DataColumn("PhoneNumber1", typeof(string));
                var phoneNumber2 = new DataColumn("PhoneNumber2", typeof(string));
                var email1 = new DataColumn("Email1", typeof(string));// { Caption = "Email1" };
                var email2 = new DataColumn("Email2", typeof(string));
                //{ Caption = "Email2" };
                inventoryTable.Columns.AddRange(
                  new[] { Id, firstName, surName, phoneNumber1, phoneNumber2, email1, email2 });
            }
            return inventoryTable;
        }

        static DataTable AddPeopleToTable(List<Person> allPeople, DataTable inventoryTable)
        {
            foreach (var c in allPeople)
            {
                var newRow = inventoryTable.NewRow();
                newRow["Id"] = c.Id;
                newRow["FirstName"] = c.FirstName;
                newRow["SurName"] = c.SurName;
                newRow["PhoneNumber1"] = c.PhoneNumbers[0].Number;
                newRow["PhoneNumber2"] = c.PhoneNumbers[1].Number;
                newRow["Email1"] = c.EmailAddresses[0].EmailLogin;
                newRow["Email2"] = c.EmailAddresses[1].EmailLogin;
                inventoryTable.Rows.Add(newRow);
            }
            return inventoryTable;
        }
        #endregion

        #region StripMenu
        private void StripMenuEneble(bool enebleMenu)
        {
            foreach (var item in contextMenuStrip1.Items)
            {
                contextMenuStrip1.Enabled = enebleMenu;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
            }
            StripMenuEneble(false);
        }

        private void RemoveFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
                DeleteFromDb deleteFromDb = new DeleteFromDb();
                deleteFromDb.DeleteAsync(id);
            }
            StripMenuEneble(false);
        }
        #endregion
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DeleteFromDb deleteFromDb = new DeleteFromDb();
            deleteFromDb.DeleteAllAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int n = dataGridView1.CurrentRow.Index;
            //string[] CurrentLineData = new string[dataGridView1.ColumnCount];
            //for (int i = 0; i < dataGridView1.ColumnCount; i++)
            //{
            //    CurrentLineData[i] = dataGridView1.Rows[n].Cells[i].Value.ToString();
            //}
            string[] CurrentLineData = ReadStringDataFromDataGridwiew();
            int Id = Convert.ToInt32(CurrentLineData[0]);
            WriteToDb writeToDb = new WriteToDb();
           // writeToDb.UpdateDb(Id, CurrentLineData);              
        }
    
        private void btnSaveNewPerson_Click(object sender, EventArgs e)
        {
            int numberOfmatches = 0;
            List<string> txtBoxes = new List<string>
            {                
                textBoxFirstName.Text,
                textBoxSurName.Text,
                textBoxPhone1.Text,
                textBoxPhone2.Text,
                textBoxEmail1.Text,
                textBoxEmail2.Text
            };

            for (int i = 0; i < txtBoxes.Count; i++)
            {
                if (i == 0 || i == 1)
                {
                    MatchCollection matches = Regex.Matches(txtBoxes[i], patterns[0]);
                    if (matches.Count > 0) numberOfmatches++;
                }
                if (i == 2 || i == 3)
                {
                    MatchCollection matches = Regex.Matches(txtBoxes[i], patterns[1]);
                    if (matches.Count > 0) numberOfmatches++;
                }
                if (i == 4 || i == 5)
                {
                    MatchCollection matches = Regex.Matches(txtBoxes[i], patterns[2]);
                    if (matches.Count > 0) numberOfmatches++;
                }
            }
            if (numberOfmatches >= 4)
            {
                if(btnSaveNewPerson.Text == "UpdateData"&&IdPerson!=0)
                {
                    WriteToDb writeToDb = new WriteToDb();
                    writeToDb.UpdateDb(IdPerson, txtBoxes);
                    btnSaveNewPerson.Text = "SaveNewPerson";
                    textBoxFirstName.Clear();
                    textBoxSurName.Clear();
                    textBoxPhone1.Clear();
                    textBoxPhone2.Clear();
                    textBoxEmail1.Clear();
                    textBoxEmail2.Clear();
                }
                else
                {
                    PreparingToWriteData(txtBoxes);
                }              
            }
            else
            {
                MessageBox.Show("Invalid data format entered");
            }         
        }

        private void PreparingToWriteData(List<string> txtBoxes)
        {
            WriteToDb writeToDb = new WriteToDb() { };
            writeToDb.ControlerFirstName = txtBoxes[0];
            writeToDb.ControlerSurName = txtBoxes[1];
            for (int i = 2; i <= 6; i++)
            {
                if (i >= 2 && i <= 3)
                {
                    writeToDb.ControlerPhoneNumbers.Add(new Models.PhoneNumber() { Number = txtBoxes[i] });
                }
                if (i >= 4 && i <= 5)
                {
                    writeToDb.ControlerEmailAdresses.Add(new Models.EmailAddress() { EmailLogin = txtBoxes[i] });
                }
            }
            writeToDb.WriteStartAsync();
        }

        private string [] ReadStringDataFromDataGridwiew()
        {
            int n = dataGridView1.CurrentRow.Index;
            string[] CurrentLineData = new string[dataGridView1.ColumnCount];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                CurrentLineData[i] = dataGridView1.Rows[n].Cells[i].Value.ToString();
            }
            return CurrentLineData;
        }
    }
}
