namespace VizsgaGyak_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            dataGridViewStudents = new DataGridView();
            buttonChoose = new Button();
            buttonLoad = new Button();
            textBoxName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBoxEmail = new TextBox();
            label5 = new Label();
            textBoxAge = new TextBox();
            buttonRegister = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 23);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 0;
            label1.Text = "Load CSV file";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 363);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 1;
            label2.Text = "Register new student";
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(134, 104);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.Size = new Size(569, 256);
            dataGridViewStudents.TabIndex = 2;
            // 
            // buttonChoose
            // 
            buttonChoose.Location = new Point(135, 56);
            buttonChoose.Name = "buttonChoose";
            buttonChoose.Size = new Size(75, 23);
            buttonChoose.TabIndex = 3;
            buttonChoose.Text = "Choose";
            buttonChoose.UseVisualStyleBackColor = true;
            buttonChoose.Click += buttonChoose_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(448, 56);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(193, 414);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(223, 23);
            textBoxName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(136, 417);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 6;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(136, 460);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 8;
            label4.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(193, 457);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(223, 23);
            textBoxEmail.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(136, 505);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 10;
            label5.Text = "Age";
            // 
            // textBoxAge
            // 
            textBoxAge.Location = new Point(193, 502);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new Size(58, 23);
            textBoxAge.TabIndex = 9;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(246, 558);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(75, 23);
            buttonRegister.TabIndex = 11;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 606);
            Controls.Add(buttonRegister);
            Controls.Add(label5);
            Controls.Add(textBoxAge);
            Controls.Add(label4);
            Controls.Add(textBoxEmail);
            Controls.Add(label3);
            Controls.Add(textBoxName);
            Controls.Add(buttonLoad);
            Controls.Add(buttonChoose);
            Controls.Add(dataGridViewStudents);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dataGridViewStudents;
        private Button buttonChoose;
        private Button buttonLoad;
        private TextBox textBoxName;
        private Label label3;
        private Label label4;
        private TextBox textBoxEmail;
        private Label label5;
        private TextBox textBoxAge;
        private Button buttonRegister;
    }
}
