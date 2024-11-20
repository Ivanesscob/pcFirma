using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            ControlBox = false;
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

                DialogResult result = MessageBox.Show("Ты уверен?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



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
                MessageBox.Show("Вы не выбрали строку!");
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
                MessageBox.Show("Вы не выбрали строку для редактирования!");
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
                string selectQuery = "select ProductName, Models,Price, Stock,Brand,Country,CategoryName from Products join Models on ProductID = Id  join Brand on Brand.Id = Models.BrandID join Counrties on Counrties.Id = Brand.CountryID join Categories on Categories.CategoryID = Models.CategoryID;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
                dataOfProducts.MultiSelect = false;
                dataOfProducts.DataSource = _userSet.Tables[0];
                dataOfProducts.Columns[0].HeaderText = "Название продукта";
                dataOfProducts.Columns[1].HeaderText = "Название модели";
                dataOfProducts.Columns[2].HeaderText = "Стоимость";
                dataOfProducts.Columns[3].HeaderText = "Кол-во";
                dataOfProducts.Columns[4].HeaderText = "Производитель";
                dataOfProducts.Columns[5].HeaderText = "Страна производителя";
                dataOfProducts.Columns[6].HeaderText = "Категория";
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

        private void toPdf_Click(object sender, EventArgs e)
        {
            ToPdf t = new ToPdf("Products.pdf", dataOfProducts);
        }
    }
}
