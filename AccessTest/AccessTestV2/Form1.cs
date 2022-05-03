using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AccessTestV2
{
    public partial class Form1 : Form
    {
        public static string ConnectionString { get; set; } = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = AccessDbTest.mdb";
        public static OleDbConnection dbCoonnection;
        int Id = 0;
        string Content;
        public Form1()
        {
            InitializeComponent();
            dbCoonnection = new OleDbConnection(ConnectionString);
            dbCoonnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "accessDbTestDataSet.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.accessDbTestDataSet.Person);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            //Content = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //ContentTb.Text = Content;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                string query = $"DELETE FROM Person WHERE [Код]={Id}";
                OleDbCommand oleDbCommand = new OleDbCommand(query, dbCoonnection);
                oleDbCommand.ExecuteNonQuery();
                MessageBox.Show("Данные удалены");
                this.personTableAdapter.Fill(this.accessDbTestDataSet.Person);
            }
            else
            {
                MessageBox.Show("Данные не выбраны");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (ContentTb.Text != "")
            {
                string query = $"INSERT INTO Person ([Имя]) VALUES ('{ContentTb.Text}')";
                OleDbCommand oleDbCommand = new OleDbCommand(query, dbCoonnection);
                // oleDbCommand.ExecuteScalar();
                oleDbCommand.ExecuteNonQuery();
                MessageBox.Show("Данные добавлены");
                this.personTableAdapter.Fill(this.accessDbTestDataSet.Person);
            }
            else
            {
                MessageBox.Show("Данные не заполнены");
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (Id != 0 && ContentTb.Text != "")
            {
                string query = $"UPDATE Person SET Имя = '{ContentTb.Text}' WHERE Код={Id}";
                OleDbCommand oleDbCommand = new OleDbCommand(query, dbCoonnection);
                // oleDbCommand.ExecuteScalar();
                oleDbCommand.ExecuteNonQuery();
                MessageBox.Show("Данные адаптированы");
                this.personTableAdapter.Fill(this.accessDbTestDataSet.Person);
            }
            else
            {
                MessageBox.Show("Данные не выбраны");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if (Id > 0)
            {
                Content = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                ContentTb.Text = Content;
            }
            else
            {
                Id = 0;
                ContentTb.Text = "";
            }
        }
    }
}
