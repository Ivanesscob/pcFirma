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
    public partial class EmbloyeesList : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        public EmbloyeesList()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataOfEmployees.SelectedRows.Count > 0 && dataOfEmployees.SelectedRows[0].Index < dataOfEmployees.Rows.Count - 1)
            {
                var selectedRowIndex = dataOfEmployees.SelectedRows[0].Index;

                DialogResult result = MessageBox.Show("Do you sure?", "Deletion confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.Yes)
                {

                    dataOfEmployees.Rows.RemoveAt(selectedRowIndex);
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
            if (dataOfEmployees.SelectedRows.Count > 0 && dataOfEmployees.SelectedRows[0].Index < dataOfEmployees.Rows.Count - 1)
            {
                selectedRowIndex = dataOfEmployees.SelectedRows[0].Index;
            }
            else
            {
                MessageBox.Show("We didn't select an edit line!");
                return;
            }
            addEditDeleteEmpl editAddPage = new addEditDeleteEmpl(selectedRowIndex, _userSet, _adapter, connection);
            editAddPage.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addEditDeleteEmpl editAddPage = new addEditDeleteEmpl(-1, _userSet, _adapter, connection);
            editAddPage.Show();
        }

        private void EmbloyeesList_Activated(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=31.128.43.172;Initial Catalog=pcFirma;User ID=sa;Password=WeNeedABetterPassword!!!1;";
            connection = new SqlConnection(connectionString);
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT * FROM Employees;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
                dataOfEmployees.MultiSelect = false;
                dataOfEmployees.DataSource = _userSet.Tables[0];
            }
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {

            dataOfEmployees.DataSource = _userSet.Tables[0];
            dataOfEmployees.Refresh();
        }
        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
        }
    }
}
