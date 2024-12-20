﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PcFirma
{
    public partial class OrdersList : Form
    {
        

        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        public OrdersList()
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
            if (dataOfPrders.SelectedRows.Count > 0 && dataOfPrders.SelectedRows[0].Index < dataOfPrders.Rows.Count - 1)
            {
                var selectedRowIndex = dataOfPrders.SelectedRows[0].Index;

                DialogResult result = MessageBox.Show("Ты уверен?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.Yes)
                {
                    Connection("select * from Orders;");
                    DataTable ordersTable = _userSet.Tables[0];
                    string id = ordersTable.Rows[selectedRowIndex]["OrderID"].ToString();
                    ordersTable.Rows[selectedRowIndex].Delete();
                    SaveData();
                    Connection("select * from OrderDetails where OrdersID = " +id+ ";");
                    ordersTable = _userSet.Tables[0];
                    ordersTable.Clear();
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

        private void changeButton_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = -1;
            if (dataOfPrders.SelectedRows.Count > 0 && dataOfPrders.SelectedRows[0].Index < dataOfPrders.Rows.Count - 1)
            {
                selectedRowIndex = dataOfPrders.SelectedRows[0].Index;
            }
            else
            {
                MessageBox.Show("Вы не выбрали строку!");
                return;
            }
            
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            chooseCust f = new chooseCust();
            f.ShowDialog();
        }

        private void OrdersList_Activated(object sender, EventArgs e)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "select OrderDate,TotalAmount,Customers.FirstName,Customers.LastName,Customers.Patronymic, Employees.FirstName,Employees.LastName,Employees.Patronymic from Orders join Customers on Orders.CustomerID = Customers.CustomerID\r\njoin Employees on Employees.EmployeeID = Orders.EmployeeID;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
                dataOfPrders.MultiSelect = false;
                dataOfPrders.DataSource = _userSet.Tables[0];
                dataOfPrders.Columns[0].HeaderText = "Дата заказа";
                dataOfPrders.Columns[1].HeaderText = "Сумма";
                dataOfPrders.Columns[2].HeaderText = "Имя покупателя";
                dataOfPrders.Columns[3].HeaderText = "Фамилия покупателя";
                dataOfPrders.Columns[4].HeaderText = "Отчество покупателя";
                dataOfPrders.Columns[5].HeaderText = "Имя продовца";
                dataOfPrders.Columns[6].HeaderText = "Фамилия продовца";
                dataOfPrders.Columns[7].HeaderText = "Отчество продовца";
                
                

            }
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {
            Connection("select OrderDate,TotalAmount,Customers.FirstName,Customers.LastName,Customers.Patronymic, Employees.FirstName,Employees.LastName,Employees.Patronymic from Orders join Customers on Orders.CustomerID = Customers.CustomerID\r\njoin Employees on Employees.EmployeeID = Orders.EmployeeID;");
            dataOfPrders.DataSource = _userSet.Tables[0];
            dataOfPrders.Refresh();
        }
        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
        }
        private void toPdf_Click(object sender, EventArgs e)
        {
            ToPdf d = new ToPdf("Orders.pdf", dataOfPrders);
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
    }
}
