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
    public partial class ReportForm : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        public ReportForm()
        {
            InitializeComponent();
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            ControlBox = false;
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                _adapter = new SqlDataAdapter("SELECT \r\n    OrderDate as \"Дата продажи\",\r\n\tCustomers.FirstName as\"Имя покупателя\",\r\n\tCustomers.LastName as\"Фамилия покупателя\",\r\n\tCustomers.Patronymic as\"Отчество покупателя\",\r\n\tCustomers.Phone as\"Телефон покупателя\",\r\n\tProducts.ProductName as\"Имя продукта\",\r\n\tSUM(UnitPrice) as \"Сумма\",\r\n\tSum(Quantity) as \"Количество\",\r\n\tCategoryName\r\n\r\nFROM \r\n    OrderDetails \r\nJOIN Orders ON OrderDetails.OrdersID = Orders.OrderID\r\nJOIN Customers ON Orders.CustomerID = Customers.CustomerID\r\nJOIN Products ON Products.ProductID = OrderDetails.ProductID\r\nJOIN Models ON Products.ModelID = Models.Id\r\nJOIN Categories ON Models.CategoryID = Categories.CategoryID\r\n\r\nGROUP BY \r\nProductName,\r\nFirstName,LastName,Patronymic,Phone,CategoryName,OrderDate\r\n\r\nORDER BY\r\nLastName;", connection);
                _adapter.Fill(_userSet);
                dg.DataSource = _userSet.Tables[0];

            }

            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toPdf_Click(object sender, EventArgs e)
        {
            ToPdf f = new ToPdf("Отчет 1.pdf", dg);
        }
    }
}
