﻿namespace PcFirma
{
    partial class addEditProduct
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
            this.AddCategory = new System.Windows.Forms.Button();
            this.AddBrand = new System.Windows.Forms.Button();
            this.AddCountry = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.baclButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ComboBoxCountry = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ComboBoxCategory = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ComboBoxBrand = new System.Windows.Forms.ComboBox();
            this.StatusPol = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddCategory
            // 
            this.AddCategory.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddCategory.Location = new System.Drawing.Point(19, 445);
            this.AddCategory.Margin = new System.Windows.Forms.Padding(2);
            this.AddCategory.Name = "AddCategory";
            this.AddCategory.Size = new System.Drawing.Size(160, 46);
            this.AddCategory.TabIndex = 8;
            this.AddCategory.Text = "Add Category";
            this.AddCategory.UseVisualStyleBackColor = true;
            this.AddCategory.Click += new System.EventHandler(this.AddCategory_Click);
            // 
            // AddBrand
            // 
            this.AddBrand.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBrand.Location = new System.Drawing.Point(19, 241);
            this.AddBrand.Margin = new System.Windows.Forms.Padding(2);
            this.AddBrand.Name = "AddBrand";
            this.AddBrand.Size = new System.Drawing.Size(160, 46);
            this.AddBrand.TabIndex = 9;
            this.AddBrand.Text = "Add brand";
            this.AddBrand.UseVisualStyleBackColor = true;
            this.AddBrand.Click += new System.EventHandler(this.AddBrand_Click);
            // 
            // AddCountry
            // 
            this.AddCountry.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddCountry.Location = new System.Drawing.Point(19, 48);
            this.AddCountry.Margin = new System.Windows.Forms.Padding(2);
            this.AddCountry.Name = "AddCountry";
            this.AddCountry.Size = new System.Drawing.Size(160, 46);
            this.AddCountry.TabIndex = 10;
            this.AddCountry.Text = "Add country";
            this.AddCountry.UseVisualStyleBackColor = true;
            this.AddCountry.Click += new System.EventHandler(this.AddCountry_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddCountry);
            this.groupBox1.Controls.Add(this.AddCategory);
            this.groupBox1.Controls.Add(this.AddBrand);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 525);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StatusPol);
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.baclButton);
            this.groupBox2.Controls.Add(this.nextButton);
            this.groupBox2.Controls.Add(this.ExitButton);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(671, 525);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(80, 445);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(160, 46);
            this.addButton.TabIndex = 34;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // baclButton
            // 
            this.baclButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baclButton.Location = new System.Drawing.Point(245, 445);
            this.baclButton.Margin = new System.Windows.Forms.Padding(2);
            this.baclButton.Name = "baclButton";
            this.baclButton.Size = new System.Drawing.Size(170, 46);
            this.baclButton.TabIndex = 33;
            this.baclButton.Text = "Back";
            this.baclButton.UseVisualStyleBackColor = true;
            this.baclButton.Visible = false;
            this.baclButton.Click += new System.EventHandler(this.baclButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextButton.Location = new System.Drawing.Point(80, 445);
            this.nextButton.Margin = new System.Windows.Forms.Padding(2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(160, 46);
            this.nextButton.TabIndex = 32;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.8F);
            this.ExitButton.Location = new System.Drawing.Point(419, 445);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(153, 46);
            this.ExitButton.TabIndex = 31;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Location = new System.Drawing.Point(227, 48);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(215, 336);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ComboBoxCountry);
            this.groupBox3.Location = new System.Drawing.Point(6, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 81);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Country";
            // 
            // ComboBoxCountry
            // 
            this.ComboBoxCountry.FormattingEnabled = true;
            this.ComboBoxCountry.Location = new System.Drawing.Point(0, 40);
            this.ComboBoxCountry.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxCountry.Name = "ComboBoxCountry";
            this.ComboBoxCountry.Size = new System.Drawing.Size(195, 21);
            this.ComboBoxCountry.TabIndex = 23;
            this.ComboBoxCountry.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCountry_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ComboBoxCategory);
            this.groupBox5.Location = new System.Drawing.Point(9, 131);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 81);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Category";
            // 
            // ComboBoxCategory
            // 
            this.ComboBoxCategory.FormattingEnabled = true;
            this.ComboBoxCategory.Location = new System.Drawing.Point(0, 40);
            this.ComboBoxCategory.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxCategory.Name = "ComboBoxCategory";
            this.ComboBoxCategory.Size = new System.Drawing.Size(195, 21);
            this.ComboBoxCategory.TabIndex = 23;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ComboBoxBrand);
            this.groupBox4.Location = new System.Drawing.Point(6, 228);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 81);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Brand";
            // 
            // ComboBoxBrand
            // 
            this.ComboBoxBrand.FormattingEnabled = true;
            this.ComboBoxBrand.Location = new System.Drawing.Point(0, 40);
            this.ComboBoxBrand.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxBrand.Name = "ComboBoxBrand";
            this.ComboBoxBrand.Size = new System.Drawing.Size(195, 21);
            this.ComboBoxBrand.TabIndex = 23;
            // 
            // StatusPol
            // 
            this.StatusPol.AutoSize = true;
            this.StatusPol.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusPol.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StatusPol.Location = new System.Drawing.Point(260, 399);
            this.StatusPol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusPol.Name = "StatusPol";
            this.StatusPol.Size = new System.Drawing.Size(0, 21);
            this.StatusPol.TabIndex = 35;
            // 
            // addEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 549);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "addEditProduct";
            this.Text = "addEditProduct";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddCategory;
        private System.Windows.Forms.Button AddBrand;
        private System.Windows.Forms.Button AddCountry;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox ComboBoxBrand;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ComboBoxCountry;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox ComboBoxCategory;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button baclButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label StatusPol;
    }
}