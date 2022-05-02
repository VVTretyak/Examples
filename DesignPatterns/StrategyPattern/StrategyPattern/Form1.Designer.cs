
namespace StrategyPattern
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSaveToWord = new System.Windows.Forms.Button();
            this.BtnSaveToJson = new System.Windows.Forms.Button();
            this.BtnSendToEmail = new System.Windows.Forms.Button();
            this.InputEndEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(520, 259);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(254, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input text";
            // 
            // BtnSaveToWord
            // 
            this.BtnSaveToWord.Location = new System.Drawing.Point(579, 24);
            this.BtnSaveToWord.Name = "BtnSaveToWord";
            this.BtnSaveToWord.Size = new System.Drawing.Size(118, 53);
            this.BtnSaveToWord.TabIndex = 2;
            this.BtnSaveToWord.Text = "Save to Microsoft word";
            this.BtnSaveToWord.UseVisualStyleBackColor = true;
            this.BtnSaveToWord.Click += new System.EventHandler(this.BtnSaveToWord_Click);
            // 
            // BtnSaveToJson
            // 
            this.BtnSaveToJson.Location = new System.Drawing.Point(579, 97);
            this.BtnSaveToJson.Name = "BtnSaveToJson";
            this.BtnSaveToJson.Size = new System.Drawing.Size(118, 53);
            this.BtnSaveToJson.TabIndex = 3;
            this.BtnSaveToJson.Text = "Save to Json file\r\n";
            this.BtnSaveToJson.UseVisualStyleBackColor = true;
            this.BtnSaveToJson.Click += new System.EventHandler(this.BtnSaveToJson_Click);
            // 
            // BtnSendToEmail
            // 
            this.BtnSendToEmail.Location = new System.Drawing.Point(580, 212);
            this.BtnSendToEmail.Name = "BtnSendToEmail";
            this.BtnSendToEmail.Size = new System.Drawing.Size(118, 53);
            this.BtnSendToEmail.TabIndex = 4;
            this.BtnSendToEmail.Text = "Send to Email";
            this.BtnSendToEmail.UseVisualStyleBackColor = true;
            this.BtnSendToEmail.Click += new System.EventHandler(this.BtnSendToEmail_Click);
            // 
            // InputEndEmail
            // 
            this.InputEndEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.InputEndEmail.Location = new System.Drawing.Point(538, 182);
            this.InputEndEmail.Name = "InputEndEmail";
            this.InputEndEmail.Size = new System.Drawing.Size(200, 23);
            this.InputEndEmail.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(585, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Email Adress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 306);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputEndEmail);
            this.Controls.Add(this.BtnSendToEmail);
            this.Controls.Add(this.BtnSaveToJson);
            this.Controls.Add(this.BtnSaveToWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "StrategyPaternExample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSaveToWord;
        private System.Windows.Forms.Button BtnSaveToJson;
        private System.Windows.Forms.Button BtnSendToEmail;
        private System.Windows.Forms.TextBox InputEndEmail;
        private System.Windows.Forms.Label label2;
    }
}

