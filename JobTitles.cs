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
    public partial class JobTitles : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        public JobTitles()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JobTitles_Activated(object sender, EventArgs e)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT JobTitle FROM JobTitles;";
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

                DialogResult result = MessageBox.Show("Ты уверен?", "Под", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.Yes)
                {
                    var row = _userSet.Tables[0].Rows[selectedRowIndex];
                    string a = row["JobTitleID"].ToString();
                    Connection("SELECT COUNT(*) FROM Employees WHERE JobTitleID = " + a + ";");
                    var row1 = _userSet.Tables[0].Rows[0];

                    if (int.Parse(row1[0].ToString()) <= 0)
                    {
                        Connection("SELECT * FROM JobTitles;");
                        data.MultiSelect = false;
                        data.DataSource = _userSet.Tables[0];
                        data.Rows.RemoveAt(selectedRowIndex);
                        SaveData();
                        UpdateDataGrid();

                    }
                    else
                    {
                        MessageBox.Show("Удаление невозможно, модель с такими параметрами уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("Ты не выбрал строку!");
                    return;
                }

            }
        }
    }
}

    
        