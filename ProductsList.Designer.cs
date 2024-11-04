namespace PcFirma
{
    partial class ProductsList
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.dataOfProducts = new System.Windows.Forms.DataGridView();
            this.CountryButton = new System.Windows.Forms.Button();
            this.CategoryButton = new System.Windows.Forms.Button();
            this.BrandsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataOfProducts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(661, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 81);
            this.label1.TabIndex = 28;
            this.label1.Text = "Products";
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.8F);
            this.ExitButton.Location = new System.Drawing.Point(1140, 639);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(204, 57);
            this.ExitButton.TabIndex = 27;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(859, 639);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(213, 57);
            this.deleteButton.TabIndex = 26;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeButton.Location = new System.Drawing.Point(576, 639);
            this.changeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(213, 57);
            this.changeButton.TabIndex = 25;
            this.changeButton.Text = "Edit";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(293, 639);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(213, 57);
            this.addButton.TabIndex = 24;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // dataOfProducts
            // 
            this.dataOfProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOfProducts.Location = new System.Drawing.Point(419, 186);
            this.dataOfProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataOfProducts.Name = "dataOfProducts";
            this.dataOfProducts.RowHeadersWidth = 51;
            this.dataOfProducts.RowTemplate.Height = 24;
            this.dataOfProducts.Size = new System.Drawing.Size(779, 437);
            this.dataOfProducts.TabIndex = 23;
            // 
            // CountryButton
            // 
            this.CountryButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountryButton.Location = new System.Drawing.Point(59, 57);
            this.CountryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CountryButton.Name = "CountryButton";
            this.CountryButton.Size = new System.Drawing.Size(213, 57);
            this.CountryButton.TabIndex = 29;
            this.CountryButton.Text = "Countries";
            this.CountryButton.UseVisualStyleBackColor = true;
            this.CountryButton.Click += new System.EventHandler(this.CountryButton_Click);
            // 
            // CategoryButton
            // 
            this.CategoryButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryButton.Location = new System.Drawing.Point(59, 150);
            this.CategoryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CategoryButton.Name = "CategoryButton";
            this.CategoryButton.Size = new System.Drawing.Size(213, 57);
            this.CategoryButton.TabIndex = 30;
            this.CategoryButton.Text = "Categories";
            this.CategoryButton.UseVisualStyleBackColor = true;
            this.CategoryButton.Click += new System.EventHandler(this.CategoryButton_Click);
            // 
            // BrandsButton
            // 
            this.BrandsButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BrandsButton.Location = new System.Drawing.Point(59, 245);
            this.BrandsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrandsButton.Name = "BrandsButton";
            this.BrandsButton.Size = new System.Drawing.Size(213, 57);
            this.BrandsButton.TabIndex = 31;
            this.BrandsButton.Text = "Brands";
            this.BrandsButton.UseVisualStyleBackColor = true;
            this.BrandsButton.Click += new System.EventHandler(this.BrandsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CountryButton);
            this.groupBox1.Controls.Add(this.BrandsButton);
            this.groupBox1.Controls.Add(this.CategoryButton);
            this.groupBox1.Location = new System.Drawing.Point(24, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 352);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // ProductsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 718);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dataOfProducts);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProductsList";
            this.Text = "ProductsList";
            this.Activated += new System.EventHandler(this.ProductsList_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataOfProducts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView dataOfProducts;
        private System.Windows.Forms.Button CountryButton;
        private System.Windows.Forms.Button CategoryButton;
        private System.Windows.Forms.Button BrandsButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}