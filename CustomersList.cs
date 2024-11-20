using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcFirma
{
    public partial class CustomersList : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        public CustomersList()
        {
            InitializeComponent();
            ControlBox = false;
        }
        
        public void UpdateDataGrid()
        {

            dataOfCustomers.DataSource = _userSet.Tables[0];
            dataOfCustomers.Refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addEditDelete editAddPage = new addEditDelete(-1, _userSet, _adapter, connection);
            editAddPage.Show();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = -1;
            if (dataOfCustomers.SelectedRows.Count > 0 && dataOfCustomers.SelectedRows[0].Index < dataOfCustomers.Rows.Count - 1)
            {
                selectedRowIndex = dataOfCustomers.SelectedRows[0].Index;
            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для редактирования!");
                return;
            }
            addEditDelete editAddPage = new addEditDelete(selectedRowIndex, _userSet, _adapter, connection);
            editAddPage.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataOfCustomers.SelectedRows.Count > 0 && dataOfCustomers.SelectedRows[0].Index < dataOfCustomers.Rows.Count - 1)
            {
                var selectedRowIndex = dataOfCustomers.SelectedRows[0].Index;

                DialogResult result = MessageBox.Show("Ты уверен?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.Yes)
                {

                    dataOfCustomers.Rows.RemoveAt(selectedRowIndex);
                    SaveData();
                    UpdateDataGrid();

                }

            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для редактирования");
                return;
            }


        }
        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
        }


        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void CustomersList_Activated(object sender, EventArgs e)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT Phone, Email, Login, Password, BirthDay, FirstName, LastName, Patronymic FROM Customers;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
                dataOfCustomers.MultiSelect = false;
                dataOfCustomers.DataSource = _userSet.Tables[0];
                dataOfCustomers.Columns[0].HeaderText = "Телефон";
                dataOfCustomers.Columns[1].HeaderText = "Почта";
                dataOfCustomers.Columns[2].HeaderText = "Логин";
                dataOfCustomers.Columns[3].HeaderText = "Пароль";
                dataOfCustomers.Columns[4].HeaderText = "Дата рождения";
                dataOfCustomers.Columns[5].HeaderText = "Имя";
                dataOfCustomers.Columns[6].HeaderText = "Фамилия";
                dataOfCustomers.Columns[7].HeaderText = "Отчество";
            }
            UpdateDataGrid();
        }

        private void toPdf_Click(object sender, EventArgs e)
        {
            ToPdf t = new ToPdf("Customers.pdf", dataOfCustomers);
        }
    }
}
