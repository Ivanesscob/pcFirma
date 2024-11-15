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

                DialogResult result = MessageBox.Show("Ты уверен?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.Yes)
                {

                    dataOfEmployees.Rows.RemoveAt(selectedRowIndex);
                    SaveData();
                    UpdateDataGrid();

                }

            }
            else
            {
                MessageBox.Show("Ты не выбрал строку!");
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
                MessageBox.Show("Ты не выбрал строку!");
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
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT Login, FirstName, LastName, Patronymic, Password, Phone, Email, BirthDay" +
                    ", JobTitle FROM Employees JOIN JobTitles ON Employees.JobTitleID = JobTitles.JobTitleID;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
                dataOfEmployees.MultiSelect = false;
                dataOfEmployees.DataSource = _userSet.Tables[0];
                dataOfEmployees.Columns[0].HeaderText = "Логин";
                dataOfEmployees.Columns[1].HeaderText = "Имя";
                dataOfEmployees.Columns[2].HeaderText = "Фамилия";
                dataOfEmployees.Columns[3].HeaderText = "Отчество";
                dataOfEmployees.Columns[4].HeaderText = "Пароль";
                dataOfEmployees.Columns[5].HeaderText = "Телефон";
                dataOfEmployees.Columns[6].HeaderText = "Почта";
                dataOfEmployees.Columns[7].HeaderText = "Дата рождения";
                dataOfEmployees.Columns[8].HeaderText = "Должность";
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

        private void toPdf_Click(object sender, EventArgs e)
        {
            ToPdf t = new ToPdf("Employees.pdf", dataOfEmployees);
        }
    }
}
