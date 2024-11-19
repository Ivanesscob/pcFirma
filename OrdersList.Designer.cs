namespace PcFirma
{
    partial class OrdersList
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
            this.dataOfPrders = new System.Windows.Forms.DataGridView();
            this.toPdf = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataOfPrders)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(603, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 81);
            this.label1.TabIndex = 28;
            this.label1.Text = "Заказы";
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.8F);
            this.ExitButton.Location = new System.Drawing.Point(1029, 607);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(204, 57);
            this.ExitButton.TabIndex = 27;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(597, 607);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(213, 57);
            this.deleteButton.TabIndex = 26;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // dataOfPrders
            // 
            this.dataOfPrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOfPrders.Location = new System.Drawing.Point(98, 154);
            this.dataOfPrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataOfPrders.Name = "dataOfPrders";
            this.dataOfPrders.RowHeadersWidth = 51;
            this.dataOfPrders.RowTemplate.Height = 24;
            this.dataOfPrders.Size = new System.Drawing.Size(1180, 437);
            this.dataOfPrders.TabIndex = 23;
            // 
            // toPdf
            // 
            this.toPdf.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toPdf.Location = new System.Drawing.Point(12, 12);
            this.toPdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toPdf.Name = "toPdf";
            this.toPdf.Size = new System.Drawing.Size(213, 58);
            this.toPdf.TabIndex = 34;
            this.toPdf.Text = "В PDF";
            this.toPdf.UseVisualStyleBackColor = true;
            this.toPdf.Click += new System.EventHandler(this.toPdf_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(184, 607);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(213, 57);
            this.addButton.TabIndex = 24;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // OrdersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 734);
            this.Controls.Add(this.toPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dataOfPrders);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrdersList";
            this.Text = "OrdersList";
            this.Activated += new System.EventHandler(this.OrdersList_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataOfPrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView dataOfPrders;
        private System.Windows.Forms.Button toPdf;
        private System.Windows.Forms.Button addButton;
    }
}