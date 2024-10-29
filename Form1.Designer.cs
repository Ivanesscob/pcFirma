namespace PcFirma
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pswdTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.statusLogIn = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log in";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusLogIn);
            this.groupBox1.Controls.Add(this.signUpButton);
            this.groupBox1.Controls.Add(this.loginButton);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(459, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 519);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(145, 445);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(88, 34);
            this.signUpButton.TabIndex = 6;
            this.signUpButton.Text = "Sign up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(90, 404);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(186, 35);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Log in";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pswdTextBox);
            this.groupBox3.Location = new System.Drawing.Point(25, 317);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 63);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Password";
            // 
            // pswdTextBox
            // 
            this.pswdTextBox.Location = new System.Drawing.Point(21, 26);
            this.pswdTextBox.Name = "pswdTextBox";
            this.pswdTextBox.Size = new System.Drawing.Size(277, 27);
            this.pswdTextBox.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.loginTextBox);
            this.groupBox2.Location = new System.Drawing.Point(25, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 63);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Login";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(21, 26);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(277, 27);
            this.loginTextBox.TabIndex = 2;
            // 
            // statusLogIn
            // 
            this.statusLogIn.AutoSize = true;
            this.statusLogIn.Location = new System.Drawing.Point(86, 373);
            this.statusLogIn.Name = "statusLogIn";
            this.statusLogIn.Size = new System.Drawing.Size(190, 20);
            this.statusLogIn.TabIndex = 7;
            this.statusLogIn.Text = "Incorrect login or password";
            this.statusLogIn.Visible = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Location = new System.Drawing.Point(929, 580);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(209, 57);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 753);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Log in";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox pswdTextBox;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label statusLogIn;
        private System.Windows.Forms.Button ExitButton;
    }
}

