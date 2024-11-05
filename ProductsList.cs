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
    public partial class ProductsList : Form
    {
        
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        public ProductsList()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataOfProducts.SelectedRows.Count > 0 && dataOfProducts.SelectedRows[0].Index < dataOfProducts.Rows.Count - 1)
            {
                var selectedRowIndex = dataOfProducts.SelectedRows[0].Index;

                DialogResult result = MessageBox.Show("Do you sure?", "Deletion confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.Yes)
                {
                    Connection("SELECT * FROM Models;");
                    DataTable productTable = _userSet.Tables[0];
                    productTable.Rows[selectedRowIndex].Delete();

                    dataOfProducts.Rows.RemoveAt(selectedRowIndex);
                    SaveData();
                    UpdateDataGrid();

                }

            }
            else
            {
                MessageBox.Show("We didn't select an edit line!");
                return;
            }
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


        private void changeButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = -1;
            if (dataOfProducts.SelectedRows.Count > 0 && dataOfProducts.SelectedRows[0].Index < dataOfProducts.Rows.Count - 1)
            {
                selectedRowIndex = dataOfProducts.SelectedRows[0].Index;
            }
            else
            {
                MessageBox.Show("We didn't select an edit line!");
                return;
            }
            addEditProduct editAddPage = new addEditProduct(selectedRowIndex, _userSet, _adapter, connection);
            editAddPage.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addEditProduct editAddPage = new addEditProduct(-1, _userSet, _adapter, connection);
            editAddPage.Show();
        }

        private void ProductsList_Activated(object sender, EventArgs e)
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
        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
        }

        private void CountryButton_Click(object sender, EventArgs e)
        {
            viewBCC viewBCC = new viewBCC(0);
            viewBCC.Show();
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            viewBCC viewBCC = new viewBCC(2);
            viewBCC.Show();
        }

        private void BrandsButton_Click(object sender, EventArgs e)
        {
            viewBCC viewBCC = new viewBCC(1);
            viewBCC.Show();
        }
    }
}
