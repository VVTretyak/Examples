
namespace ProxyPatern
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameOfPerson = new System.Windows.Forms.TextBox();
            this.PersonsPhoneNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveNewPerson = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UpdateClientData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // NameOfPerson
            // 
            this.NameOfPerson.Location = new System.Drawing.Point(435, 29);
            this.NameOfPerson.Name = "NameOfPerson";
            this.NameOfPerson.Size = new System.Drawing.Size(171, 20);
            this.NameOfPerson.TabIndex = 1;
            // 
            // PersonsPhoneNumber
            // 
            this.PersonsPhoneNumber.Location = new System.Drawing.Point(435, 83);
            this.PersonsPhoneNumber.Name = "PersonsPhoneNumber";
            this.PersonsPhoneNumber.Size = new System.Drawing.Size(171, 20);
            this.PersonsPhoneNumber.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(470, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "NamePerson";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(465, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "PhoneNumber";
            // 
            // SaveNewPerson
            // 
            this.SaveNewPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveNewPerson.Location = new System.Drawing.Point(470, 126);
            this.SaveNewPerson.Name = "SaveNewPerson";
            this.SaveNewPerson.Size = new System.Drawing.Size(107, 23);
            this.SaveNewPerson.TabIndex = 5;
            this.SaveNewPerson.Text = "Save";
            this.SaveNewPerson.UseVisualStyleBackColor = true;
            this.SaveNewPerson.Click += new System.EventHandler(this.SaveNewPerson_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(171, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Persons";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(392, 121);
            this.dataGridView1.TabIndex = 0;
            // 
            // UpdateClientData
            // 
            this.UpdateClientData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateClientData.Location = new System.Drawing.Point(297, 2);
            this.UpdateClientData.Name = "UpdateClientData";
            this.UpdateClientData.Size = new System.Drawing.Size(107, 23);
            this.UpdateClientData.TabIndex = 7;
            this.UpdateClientData.Text = "Update table";
            this.UpdateClientData.UseVisualStyleBackColor = true;
            this.UpdateClientData.Click += new System.EventHandler(this.UpdateClientData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 167);
            this.Controls.Add(this.UpdateClientData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SaveNewPerson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PersonsPhoneNumber);
            this.Controls.Add(this.NameOfPerson);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Demo proxy pattern";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox NameOfPerson;
        private System.Windows.Forms.TextBox PersonsPhoneNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveNewPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button UpdateClientData;
    }
}

