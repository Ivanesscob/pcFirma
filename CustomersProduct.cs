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

        private int id;

        Dictionary<string, int> products = new Dictionary<string, int>();

        public CustomersProduct(string log)
        {
            InitializeComponent();
            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.MeasureItem += ListBox1_MeasureItem;
            listBox1.DrawItem += ListBox1_DrawItem;
            id = int.Parse(log);


        }
        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            
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
        private void Connection(string selectQuery)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);

            }
        }

        public void UpdateDataGrid()
        {

            dataOfProducts.DataSource = _userSet.Tables[0];
            dataOfProducts.Refresh();
        }
        public static string ShowInputDialog(string text)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = "Input Quantity"
            };
            Label textLabel = new Label() { Left = 10, Top = 20, Text = text };
            TextBox inputBox = new TextBox() { Left = 10, Top = 50, Width = 260 };
            Button confirmation = new Button() { Text = "OK", Left = 200, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : string.Empty;
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = -1;
            if (dataOfProducts.SelectedRows.Count > 0 && dataOfProducts.SelectedRows[0].Index < dataOfProducts.Rows.Count - 1)
            {
                selectedRowIndex = dataOfProducts.SelectedRows[0].Index;
                var row = _userSet.Tables[0].Rows[selectedRowIndex];
                string result = ShowInputDialog("Enter Quantity:");
                if (int.TryParse(result, out int quantity) && quantity >= 1)
                {
                    if (products.ContainsKey(row["ProductName"].ToString()))
                    {
                        products[row["ProductName"].ToString()] += quantity;
                    }
                    else
                    {
                        products.Add(row["ProductName"].ToString(), quantity);
                    }
                    listBox1.Items.Clear();

                    foreach (var item in products)
                    {
                        listBox1.Items.Add(item.Key + " Qty: " + item.Value);
                    }

                }
                else
                {
                    MessageBox.Show("Invalid quantity entered. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                buyProduct buyProduct = new buyProduct();
                buyProduct.ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool q = true;
            Connection("SELECT * FROM Products");
            foreach (DataRow row in _userSet.Tables[0].Rows)
            {
                if (products.ContainsKey(row["ProductName"].ToString().Trim()))
                {
                    if (int.Parse(row["Stock"].ToString()) < products[(row["ProductName"].ToString().Trim())])
                    {
                        MessageBox.Show("Product: " +row["ProductName"].ToString() + ". Quantity of this product no, select a lower value");
                        q = false;
                    }
                }
            }
            if (q) { 
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProfileCustpmer profileCustpmer = new ProfileCustpmer(id);
            profileCustpmer.Show();
        }
    }
}
