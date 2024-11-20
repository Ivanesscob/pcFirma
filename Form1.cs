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
    public partial class Form1 : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        public static string idEm;
        public Form1()
        {
            InitializeComponent();
            pswdTextBox.PasswordChar = '*';
            Connection("SELECT * FROM Customers;");
            ControlBox = false;
        }
        private void Connection(string selectQuery)
        {
            DataClass s = new DataClass();
            SqlConnection connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Connection("SELECT * FROM Employees;");
            bool statusLog = true;
            foreach (DataRow row in _userSet.Tables[0].Rows)
            {
                if (row["Login"].ToString().Trim() == loginTextBox.Text.Trim() && row["Password"].ToString().Trim() == pswdTextBox.Text.Trim())
                {
                    MainMenu m = new MainMenu(int.Parse(row["JobTitleID"].ToString()));
                    m.Show();
                    Hide();
                    statusLog = false;
                    statusLogIn.Visible = false;
                    idEm = row["EmployeeID"].ToString();
                    return;
                }
            }
            Connection("SELECT * FROM Customers;");
            foreach (DataRow row in _userSet.Tables[0].Rows)
            {
                if (row["Login"].ToString().Trim() == loginTextBox.Text.Trim() && row["Password"].ToString().Trim() == pswdTextBox.Text.Trim())
                {
                    CustomersProduct product = new CustomersProduct(row["CustomerID"].ToString().Trim(), "1");
                    product.Show();
                    Hide();
                    statusLog = false;
                    statusLogIn.Visible = false;
                    return;
                }
                
            }
            
            if (statusLog)
            {
                statusLogIn.Visible = true;
            }
        }

        

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RgisterForm g = new RgisterForm(_userSet, _adapter);
            g.Show();
        }
    }
}
