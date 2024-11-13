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
    public partial class buyProduct : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;

        private Dictionary<string, int> categories = new Dictionary<string, int>();
        private Dictionary<string, int> countries = new Dictionary<string, int>();
        private Dictionary<string, int> brands = new Dictionary<string, int>();
        private Dictionary<string, int> products = new Dictionary<string, int>();

        private DataSet _userSetForDic;
        private SqlDataAdapter _adapterForDic;

        private DataSet _userSetForDicBr;
        private SqlDataAdapter _adapterForDicBr;

        private CustomersProduct a;

        string selectCategories;

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
        public buyProduct(CustomersProduct f)
        {
            InitializeComponent();
            a = f;
            price.Text = "-";
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT * FROM Products;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
            }

            _userSetForDic = new DataSet();
            selectCategories = "SELECT * FROM Counrties";
            _adapterForDic = new SqlDataAdapter(selectCategories, connection);
            _adapterForDic.Fill(_userSetForDic);

            foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
            {
                countries.Add(categoryRow["Country"].ToString().Trim(),
                    Convert.ToInt32(categoryRow["Id"]));
            }
            ComboBoxCountry.DataSource = countries.Keys.ToList();

            _userSetForDic = new DataSet();
            selectCategories = "SELECT * FROM Categories";
            _adapterForDic = new SqlDataAdapter(selectCategories, connection);
            _adapterForDic.Fill(_userSetForDic);

            foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
            {
                categories.Add(categoryRow["CategoryName"].ToString().Trim(),
                    Convert.ToInt32(categoryRow["CategoryID"]));
            }
            ComboBoxCategory.DataSource = categories.Keys.ToList();

            

        }

        private void addButton_Click(object sender, EventArgs e)
        {
          if (String.IsNullOrEmpty(comboBoxName.Text) || String.IsNullOrEmpty(stock.Text))
            {
                StatusPol.Visible = true;
                StatusPol.Text = "Fill all fields!";
            }
            else
            {
                var row = _userSetForDic.Tables[0].Rows[comboBoxName.SelectedIndex];
                a.addInCart(row["ProductName"].ToString().Trim(), int.Parse(stock.Text));
                Close();
            }
            
        }

        private void baclButton_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
            addButton.Visible = false;
            baclButton.Visible = false;
            groupBox7.Visible = false;
            groupBox6.Visible = true;
            stock.Text = string.Empty;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(ComboBoxBrand.Text) || String.IsNullOrEmpty(ComboBoxCategory.Text) || String.IsNullOrEmpty(ComboBoxCountry.Text))
            {
                StatusPol.Visible = true;
                StatusPol.Text = "Fill all fields";
            }
            else
            {
                groupBox6.Visible = false;
                addButton.Visible = true;
                baclButton.Visible = true;
                groupBox7.Visible = true;
                StatusPol.Visible = false;

                products.Clear();
                comboBoxName.Text = null;
                _userSetForDic = new DataSet();
                selectCategories = "SELECT * FROM Products join Models on Models.Id = Products.ProductID " +
                    "join Categories on Categories.CategoryID = Models.CategoryID join Brand on Brand.Id = Models.BrandID " +
                    "join Counrties on Counrties.Id = Brand.CountryID " +
                    "where Categories.CategoryID = " + categories[ComboBoxCategory.Text] + " and Counrties.Id = " + countries[ComboBoxCountry.Text] + " and Brand.Id = " + brands[ComboBoxBrand.Text] + ";";
                _adapterForDic = new SqlDataAdapter(selectCategories, connection);
                _adapterForDic.Fill(_userSetForDic);

                foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
                {
                    products.Add(categoryRow["ProductName"].ToString().Trim(),
                        Convert.ToInt32(categoryRow["ProductID"]));
                }
                comboBoxName.DataSource = products.Keys.ToList();
            }
        }


        private void ComboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            brands.Clear();
            ComboBoxBrand.Text = null;
            DataClass s = new DataClass();
            int a = countries[ComboBoxCountry.SelectedItem.ToString()];


            _userSetForDicBr = new DataSet();
            connection = new SqlConnection(s.ConnectionString());
            string selectCategoriesBr = "SELECT Brand.Id, Brand.Brand, Brand.CountryID FROM Brand WHERE Brand.CountryID = " + a.ToString() + ";";
            _adapterForDicBr = new SqlDataAdapter(selectCategoriesBr, connection);
            _adapterForDicBr.Fill(_userSetForDicBr);

            foreach (DataRow categoryRow in _userSetForDicBr.Tables[0].Rows)
            {
                brands.Add(categoryRow["Brand"].ToString(),
                    Convert.ToInt32(categoryRow["Id"]));
            }
            ComboBoxBrand.DataSource = brands.Keys.ToList();
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (comboBoxName.Text != String.Empty)
            {
                Connection("SELECT * FROM Products WHERE ProductID = " + products[comboBoxName.Text] + ";");
                var row = _userSet.Tables[0].Rows[0];
                price.Text = row["Price"].ToString();

            }
            else
            {
                price.Text = "-";
            }
        }
    }
    
}
