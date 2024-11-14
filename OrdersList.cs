using System;
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
            EditOrders es = new EditOrders();
            es.ShowDialog();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EditOrders es = new EditOrders();
            es.ShowDialog();
        }

        private void OrdersList_Activated(object sender, EventArgs e)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT * FROM Orders;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
                dataOfPrders.MultiSelect = false;
                dataOfPrders.DataSource = _userSet.Tables[0];
                dataOfPrders.Columns[0].Visible = false;
            }
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {

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
