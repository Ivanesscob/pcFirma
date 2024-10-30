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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PcFirma
{
    public partial class addEditProduct : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;

        private Dictionary<string, int> categories = new Dictionary<string, int>();
        private Dictionary<string, int> countries = new Dictionary<string, int>();
        private Dictionary<string, int> brands = new Dictionary<string, int>();

        private DataSet _userSetForDic;
        private SqlDataAdapter _adapterForDic;

        string selectCategories;
        public addEditProduct()
        {
            InitializeComponent();
        }
        public addEditProduct(int id, DataSet dataset, SqlDataAdapter adapter, SqlConnection connection)
        {
            InitializeComponent();
            _userSetForDic = new DataSet();
            selectCategories = "SELECT * FROM Counrties";
            _adapterForDic = new SqlDataAdapter(selectCategories, connection);
            _adapterForDic.Fill(_userSetForDic);

            foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
            {
                countries.Add(categoryRow["Country"].ToString(),
                    Convert.ToInt32(categoryRow["Id"]));
            }
            ComboBoxCountry.DataSource = countries.Keys.ToList();

            _userSetForDic = new DataSet();
            selectCategories = "SELECT * FROM Categories";
            _adapterForDic = new SqlDataAdapter(selectCategories, connection);
            _adapterForDic.Fill(_userSetForDic);

            foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
            {
                categories.Add(categoryRow["CategoryName"].ToString(),
                    Convert.ToInt32(categoryRow["CategoryID"]));
            }
            ComboBoxCategory.DataSource = categories.Keys.ToList();
        }
        

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void baclButton_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
            addButton.Visible = false;
            baclButton.Visible = false;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(ComboBoxBrand.Text) || String.IsNullOrEmpty(ComboBoxCategory.Text) || String.IsNullOrEmpty(ComboBoxCountry.Text))
            {
                StatusPol.Visible = true;
                StatusPol.Text = "Fill all fields";
            }
            else
            {
                groupBox6.Visible = false;
                addButton.Visible = true;
                baclButton.Visible = true;
            }
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        

        private void AddBrand_Click(object sender, EventArgs e)
        {
            Connection("SELECT * FROM Brand;");
            addCountryCategoryCountry addCountryCategoryCountry = new addCountryCategoryCountry(1, _userSet, _adapter, connection);
            addCountryCategoryCountry.Show();
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            Connection("SELECT * FROM Categories;");
            addCountryCategoryCountry addCountryCategoryCountry = new addCountryCategoryCountry(2, _userSet, _adapter, connection);
            addCountryCategoryCountry.Show();
        }

        private void AddCountry_Click(object sender, EventArgs e)
        {
            Connection("SELECT * FROM Counrties;");
            addCountryCategoryCountry addCountryCategoryCountry = new addCountryCategoryCountry(0, _userSet, _adapter, connection);
            addCountryCategoryCountry.Show();
            
        }
        private void Connection(string selectQuery)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionStrings);
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);

            }
        }

        private void ComboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = ComboBoxCountry.SelectedIndex;
            _userSetForDic = new DataSet();
            selectCategories = "SELECT Brand.Id, Brand.Brand, Brand.CountryID FROM Brand WHERE Brand.CountryID = " + a.ToString()+";";
            _adapterForDic = new SqlDataAdapter(selectCategories, connection);
            _adapterForDic.Fill(_userSetForDic);

            foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
            {
                countries.Add(categoryRow["Brand"].ToString(),
                    Convert.ToInt32(categoryRow["Id"]));
            }
            ComboBoxBrand.DataSource = brands.Keys.ToList();
        }
    }
}
