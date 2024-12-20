﻿namespace PcFirma
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.EmployeesButton = new System.Windows.Forms.Button();
            this.OrdersButton = new System.Windows.Forms.Button();
            this.ProductsButton = new System.Windows.Forms.Button();
            this.CustomersList = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dg = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(427, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 81);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбор действия";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeesButton
            // 
            this.EmployeesButton.Font = new System.Drawing.Font("Yu Gothic UI", 19.8F);
            this.EmployeesButton.Location = new System.Drawing.Point(8, 178);
            this.EmployeesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EmployeesButton.Name = "EmployeesButton";
            this.EmployeesButton.Size = new System.Drawing.Size(233, 71);
            this.EmployeesButton.TabIndex = 9;
            this.EmployeesButton.Text = "Сотрудники";
            this.EmployeesButton.UseVisualStyleBackColor = true;
            this.EmployeesButton.Click += new System.EventHandler(this.EmployeesButton_Click);
            // 
            // OrdersButton
            // 
            this.OrdersButton.Font = new System.Drawing.Font("Yu Gothic UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrdersButton.Location = new System.Drawing.Point(8, 18);
            this.OrdersButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OrdersButton.Name = "OrdersButton";
            this.OrdersButton.Size = new System.Drawing.Size(233, 71);
            this.OrdersButton.TabIndex = 10;
            this.OrdersButton.Text = "Заказы";
            this.OrdersButton.UseVisualStyleBackColor = true;
            this.OrdersButton.Click += new System.EventHandler(this.OrdersButton_Click);
            // 
            // ProductsButton
            // 
            this.ProductsButton.Font = new System.Drawing.Font("Yu Gothic UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductsButton.Location = new System.Drawing.Point(8, 18);
            this.ProductsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProductsButton.Name = "ProductsButton";
            this.ProductsButton.Size = new System.Drawing.Size(233, 71);
            this.ProductsButton.TabIndex = 11;
            this.ProductsButton.Text = "Продукция";
            this.ProductsButton.UseVisualStyleBackColor = true;
            this.ProductsButton.Click += new System.EventHandler(this.ProductsButton_Click);
            // 
            // CustomersList
            // 
            this.CustomersList.Font = new System.Drawing.Font("Yu Gothic UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CustomersList.Location = new System.Drawing.Point(5, 169);
            this.CustomersList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomersList.Name = "CustomersList";
            this.CustomersList.Size = new System.Drawing.Size(233, 71);
            this.CustomersList.TabIndex = 12;
            this.CustomersList.Text = "Покупатели";
            this.CustomersList.UseVisualStyleBackColor = true;
            this.CustomersList.Click += new System.EventHandler(this.CustomersList_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Location = new System.Drawing.Point(975, 578);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(233, 57);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Yu Gothic UI", 15.8F);
            this.button6.Location = new System.Drawing.Point(5, 185);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(233, 71);
            this.button6.TabIndex = 13;
            this.button6.Text = "Категории";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Yu Gothic UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(8, 110);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(233, 71);
            this.button8.TabIndex = 14;
            this.button8.Text = "Бренды";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Yu Gothic UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(5, 34);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(233, 71);
            this.button7.TabIndex = 15;
            this.button7.Text = "Страны";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Location = new System.Drawing.Point(843, 210);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(247, 350);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI", 15.8F);
            this.button2.Location = new System.Drawing.Point(8, 260);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 71);
            this.button2.TabIndex = 16;
            this.button2.Text = "Должности";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EmployeesButton);
            this.groupBox2.Controls.Add(this.ProductsButton);
            this.groupBox2.Location = new System.Drawing.Point(552, 247);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(247, 265);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CustomersList);
            this.groupBox3.Controls.Add(this.OrdersButton);
            this.groupBox3.Location = new System.Drawing.Point(251, 247);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(247, 265);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI", 19.8F);
            this.button1.Location = new System.Drawing.Point(20, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 71);
            this.button1.TabIndex = 20;
            this.button1.Text = "Отчет - 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Yu Gothic UI", 19.8F);
            this.button3.Location = new System.Drawing.Point(281, 22);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(233, 71);
            this.button3.TabIndex = 21;
            this.button3.Text = "Отчет - 2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(259, 554);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(535, 110);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Отчеты";
            // 
            // dg
            // 
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(35, 15);
            this.dg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dg.Name = "dg";
            this.dg.RowHeadersWidth = 51;
            this.dg.Size = new System.Drawing.Size(364, 185);
            this.dg.TabIndex = 23;
            this.dg.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 702);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainMenu";
            this.Text = "Меню";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EmployeesButton;
        private System.Windows.Forms.Button OrdersButton;
        private System.Windows.Forms.Button ProductsButton;
        private System.Windows.Forms.Button CustomersList;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dg;
    }
}