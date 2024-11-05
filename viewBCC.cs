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
            if (i == 0)
            {
                label1.Text = "Countries";
                bcc = "Counrties;";
            }
            else if (i == 1)
            {
                label1.Text = "Brands";
                bcc = "Brand;";
                
            }
            else
            {
                label1.Text = "Categories";
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (data.SelectedRows.Count > 0 && data.SelectedRows[0].Index < data.Rows.Count - 1)
            {
                var selectedRowIndex = data.SelectedRows[0].Index;

                DialogResult result = MessageBox.Show("Do you sure?", "Deletion confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.Yes)
                {

                    data.Rows.RemoveAt(selectedRowIndex);
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

        private void changeButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = -1;
            if (data.SelectedRows.Count > 0 && data.SelectedRows[0].Index < data.Rows.Count - 1)
            {
                selectedRowIndex = data.SelectedRows[0].Index;
            }
            else
            {
                MessageBox.Show("We didn't select an edit line!");
                return;
            }
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
                string selectQuery = "SELECT * FROM "+ bcc;
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
                data.MultiSelect = false;
                data.DataSource = _userSet.Tables[0];
            }
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {

            data.DataSource = _userSet.Tables[0];
            data.Refresh();
        }
    }
}
