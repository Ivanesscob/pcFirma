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
    public partial class viewBCC : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;

        private string bcc;
        private int bbc;
        public viewBCC(int i)
        {
            bbc = i;

            InitializeComponent();
            ControlBox = false;
            if (i == 0)
            {
                label1.Text = "Страны";
                bcc = "Counrties;";
                
            }
            else if (i == 1)
            {
                label1.Text = "Бренды";
                bcc = "Brand;";
                
            }
            else
            {
                label1.Text = "Категории";
                bcc = "Categories;";
                
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
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
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (data.SelectedRows.Count > 0 && data.SelectedRows[0].Index < data.Rows.Count - 1)
            {
                var selectedRowIndex = data.SelectedRows[0].Index;

                DialogResult result = MessageBox.Show("Ты уверен?", "Подтверджение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.Yes)
                {

                    if (bbc == 0)
                    {
                        var row = _userSet.Tables[0].Rows[selectedRowIndex];
                        string a = row["Id"].ToString();
                        Connection("SELECT COUNT(*) FROM Models WHERE CountryID = " + a+";");
                        var row1 = _userSet.Tables[0].Rows[0];
                        
                        if (int.Parse(row1[0].ToString()) <= 0)
                        {
                            Connection("SELECT COUNT(*) FROM Brand WHERE CountryID = " + a+";");
                            row1 = _userSet.Tables[0].Rows[0];
                            if ((int.Parse(row1[0].ToString()) <= 0)){

                                Connection("SELECT * FROM Counrties;");
                                data.MultiSelect = false;
                                data.DataSource = _userSet.Tables[0];
                                data.Rows.RemoveAt(selectedRowIndex);
                                SaveData();
                                UpdateDataGrid();
                            }
                            else
                            {
                                MessageBox.Show("Удаление невозможно, бренд с такими параметрами существует");
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Удаление невозможно, модель с такими параметрами существует");
                        }
                    }
                    else if (bbc == 1)
                    {
                        var row = _userSet.Tables[0].Rows[selectedRowIndex];
                        string a = row["Id"].ToString();
                        Connection("SELECT COUNT(*) FROM Models WHERE BrandID = " + a + ";");
                        var row1 = _userSet.Tables[0].Rows[0];

                        if (int.Parse(row1[0].ToString()) <= 0)
                        {
                            Connection("SELECT * FROM Brand;");
                            data.MultiSelect = false;
                            data.DataSource = _userSet.Tables[0];
                            data.Rows.RemoveAt(selectedRowIndex);
                            SaveData();
                            UpdateDataGrid();
                            
                        }
                        else
                        {
                            MessageBox.Show("Удаление невозможно, модель с такими параметрами существует");
                        }

                    }
                    else if (bbc == 2)
                    {
                        var row = _userSet.Tables[0].Rows[selectedRowIndex];
                        string a = row["CategoryID"].ToString();
                        Connection("SELECT COUNT(*) FROM Models WHERE CategoryID = " + a + ";");
                        row = _userSet.Tables[0].Rows[0];
                        if (int.Parse(row[0].ToString()) <= 0)
                        {
                            Connection("SELECT * FROM Categories;");
                            data.MultiSelect = false;
                            data.DataSource = _userSet.Tables[0];
                            data.Rows.RemoveAt(selectedRowIndex);
                            SaveData();
                            UpdateDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("Удаление невозможно, модель с такими параметрами существует");
                        }
                    }
                    

                }

            }
            else
            {
                MessageBox.Show("Ты не выбрал строку редактирования");
                return;
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = -1;
            if (data.SelectedRows.Count > 0 && data.SelectedRows[0].Index < data.Rows.Count - 1)
            {
                selectedRowIndex = data.SelectedRows[0].Index;

                if (bbc == 0)
                {
                    addCountryCategoryCountry editAddPage = new addCountryCategoryCountry(0, selectedRowIndex, _userSet, _adapter, connection);
                    editAddPage.Show();
                }
                else if (bbc == 1)
                {
                    addCountryCategoryCountry editAddPage = new addCountryCategoryCountry(1, selectedRowIndex, _userSet, _adapter, connection);
                    editAddPage.Show();

                }
                else
                {
                    addCountryCategoryCountry editAddPage = new addCountryCategoryCountry(2, selectedRowIndex, _userSet, _adapter, connection);
                    editAddPage.Show();
                }
            }
            else
            {
                MessageBox.Show("Ты не выбрал строку редактирования");
                return;
            }
            
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addCountryCategoryCountry a = new addCountryCategoryCountry(bbc, -1,_userSet, _adapter, connection);
            a.ShowDialog();
        }

        private void viewBCC_Activated(object sender, EventArgs e)
        {
            
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery;
                if (bcc == "Brand;")
                {
                    selectQuery = "SELECT Brand,Country FROM Brand join Counrties on Brand.CountryID = Counrties.Id;";
                    _adapter = new SqlDataAdapter(selectQuery, connection);
                    _adapter.Fill(_userSet);
                    data.MultiSelect = false;
                    data.DataSource = _userSet.Tables[0];
                    data.Columns[0].HeaderText = "Производитель";
                    data.Columns[1].HeaderText = "Страна";


                }
                else
                {
                   selectQuery = "SELECT * FROM " + bcc; _adapter = new SqlDataAdapter(selectQuery, connection);
                    _adapter.Fill(_userSet);
                    data.MultiSelect = false;
                    data.DataSource = _userSet.Tables[0];
                    data.Columns[0].Visible = false;
                    
                    if (bcc == "Categories;")
                    {
                        data.Columns[1].HeaderText = "Категория";
                    }
                    else
                    {
                        data.Columns[1].HeaderText = "Страна";
                    }
                }

                
                
            }
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {

            data.DataSource = _userSet.Tables[0];
            data.Refresh();
        }

        private void toPdf_Click(object sender, EventArgs e)
        {
            if (bbc == 0)
            {
                ToPdf t = new ToPdf("Countreis.pdf",data);
            }
            else if (bbc == 1)
            {
                ToPdf t = new ToPdf("Brands.pdf", data);
            }
            else
            {
                ToPdf t = new ToPdf("Categories.pdf", data);
            }
        }
    }
}
