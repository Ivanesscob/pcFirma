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
    public partial class chooseCust : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        public chooseCust()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT * FROM Customers;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
                foreach (DataRow row in _userSet.Tables[0].Rows)
                {
                    if (row["Phone"].ToString() == textBox1.Text.ToString().Trim())
                    {
                        CustomersProduct f = new CustomersProduct(row["CustomerID"].ToString(),Form1.idEm);
                        f.ShowDialog();
                        return;
                    }
                }
            }
        }
    }
}
