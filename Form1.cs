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
using MySql.Data.MySqlClient;

namespace PcFirma
{
    public partial class Form1 : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        public Form1()
        {
            InitializeComponent();
            pswdTextBox.PasswordChar = '*';

            DataClass s = new DataClass();
            SqlConnection connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string selectQuery = "SELECT * FROM Employees;";
                _adapter = new SqlDataAdapter(selectQuery, connection);
                _adapter.Fill(_userSet);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            bool statusLog = true;
            foreach (DataRow row in _userSet.Tables[0].Rows)
            {
                if (row["Login"].ToString() == loginTextBox.Text && row["Password"].ToString() == pswdTextBox.Text)
                {
                    MainMenu m = new MainMenu();
                    m.Show();
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

        private void signUpButton_Click(object sender, EventArgs e)
        {
            RgisterForm g = new RgisterForm(_userSet, _adapter);
            g.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
