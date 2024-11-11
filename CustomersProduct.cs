using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcFirma
{
    public partial class CustomersProduct : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;

        public CustomersProduct()
        {
            InitializeComponent();
            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.MeasureItem += ListBox1_MeasureItem;
            listBox1.DrawItem += ListBox1_DrawItem;
            listBox1.Items.Add(1);

        }
        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // Установите высоту каждого элемента
            e.ItemHeight = 50;
        }

        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            
            string itemText = listBox1.Items[e.Index].ToString();

           
            e.DrawBackground();

            
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center; 
                stringFormat.LineAlignment = StringAlignment.Center; 

                
                using (Brush textBrush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds, stringFormat);
                }
            }


            
            e.Graphics.DrawRectangle(Pens.Gray, e.Bounds);

            
            e.DrawFocusRectangle();
        }


        private void CustomersProduct_Activated(object sender, EventArgs e)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT * FROM Products;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
                dataOfProducts.MultiSelect = false;
                dataOfProducts.DataSource = _userSet.Tables[0];
            }
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {

            dataOfProducts.DataSource = _userSet.Tables[0];
            dataOfProducts.Refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = -1;
            if (dataOfProducts.SelectedRows.Count > 0 && dataOfProducts.SelectedRows[0].Index < dataOfProducts.Rows.Count - 1)
            {
                selectedRowIndex = dataOfProducts.SelectedRows[0].Index;
            }
            else
            {
                
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you sure?", "Deletion confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



            if (result == DialogResult.Yes)
            {

                if (listBox1.SelectedItem != null)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    MessageBox.Show("Product removed from cart");
                }

            }
            
        }
    }
}
