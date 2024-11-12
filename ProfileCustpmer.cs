using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcFirma
{
    public partial class ProfileCustpmer : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;

        private DataSet _userSetdop;
        private SqlDataAdapter _adapterdop;
        private int id;
        public ProfileCustpmer(int id)
        {
            InitializeComponent();
            this.id = id;
  
            

            DataClass s = new DataClass();
            SqlConnection connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {

                _adapter = new SqlDataAdapter("SELECT * FROM Customers;", connection);
                _adapter.Fill(_userSet);
            }
            foreach (DataRow row in _userSet.Tables[0].Rows)
            {
                if (row["CustomerID"].ToString().Trim() == id.ToString().Trim())
                {
                    label1.Text = row["FirstName"].ToString();
                    label2.Text = row["LastName"].ToString();
                    label3.Text = row["Patronymic"].ToString();
                    label4.Text = row["Phone"].ToString();
                    label5.Text = row["Login"].ToString();
                    label6.Text = row["Email"].ToString();
                    label7.Text = Convert.ToDateTime(row["BirthDay"]).ToString("dd.MM.yyyy");


                }

            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProfileCustpmer_Activated(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DataClass s = new DataClass();
            SqlConnection connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {

                _adapter = new SqlDataAdapter("select * from Orders where CustomerID =" + id.ToString(), connection);
                _adapter.Fill(_userSet);

            }
            foreach (DataRow row in _userSet.Tables[0].Rows)
            {
                
                SqlConnection connection1 = new SqlConnection(s.ConnectionString());
                connection1.Open();
                _userSetdop = new DataSet();
                if (connection1.State == System.Data.ConnectionState.Open)
                {
                    string a = "";
                    _adapterdop = new SqlDataAdapter("select ProductName, Stock from Orders join OrderDetails on OrderDetails.OrdersID = Orders.OrderID join Products on Products.ProductID = OrderDetails.ProductID where Orders.CustomerID = " +id.ToString() + " and Orders.OrderID = "+ row["OrderID"].ToString() +";", connection1);
                    _adapterdop.Fill(_userSetdop);
                    foreach (DataRow row1 in _userSetdop.Tables[0].Rows)
                    {
                        a += row1["ProductName"].ToString().Trim() + " - " + row1["Stock"].ToString() + " ";
                    }
                    
                    listBox1.Items.Add(a);
                }
            }

        }
       
    }
}
