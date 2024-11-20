using System;
using System.Windows.Forms;

using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Management;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Linq;


namespace PcFirma
{
    public partial class MainMenu : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        public MainMenu(int id)
        {


            InitializeComponent();
            if (id == 3)
            {
                groupBox1.Visible = false;
                groupBox4.Visible = false;
            }
            if (id >= 4) { groupBox2.Visible = false; }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
            Form1 f = new Form1();
            f.ShowDialog();

        }

        private void CustomersList_Click(object sender, EventArgs e)
        {
            CustomersList l = new CustomersList();
            l.ShowDialog();
        }

        private void EmployeesButton_Click(object sender, EventArgs e)
        {
            EmbloyeesList l = new EmbloyeesList();
            l.ShowDialog();
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            OrdersList l = new OrdersList();
            l.ShowDialog();
        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            ProductsList productsList = new ProductsList();
            productsList.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            viewBCC t = new viewBCC(0);
            t.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            viewBCC t = new viewBCC(1);
            t.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            viewBCC t = new viewBCC(2);
            t.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JobTitles t = new JobTitles();
            t.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                _adapter = new SqlDataAdapter("SELECT \r\n    OrderDate as \"Дата продажи\",\r\n\tCustomers.FirstName as\"Имя покупателя\",\r\n\tCustomers.LastName as\"Фамилия покупателя\",\r\n\tCustomers.Patronymic as\"Отчество покупателя\",\r\n\tCustomers.Phone as\"Телефон покупателя\",\r\n\tProducts.ProductName as\"Имя продукта\",\r\n\tSUM(UnitPrice) as \"Сумма\",\r\n\tSum(Quantity) as \"Количество\",\r\n\tCategoryName\r\n\r\nFROM \r\n    OrderDetails \r\nJOIN Orders ON OrderDetails.OrdersID = Orders.OrderID\r\nJOIN Customers ON Orders.CustomerID = Customers.CustomerID\r\nJOIN Products ON Products.ProductID = OrderDetails.ProductID\r\nJOIN Models ON Products.ModelID = Models.Id\r\nJOIN Categories ON Models.CategoryID = Categories.CategoryID\r\n\r\nGROUP BY \r\nProductName,\r\nFirstName,LastName,Patronymic,Phone,CategoryName,OrderDate\r\n\r\nORDER BY\r\nLastName;", connection);
                _adapter.Fill(_userSet);
                dg.DataSource = _userSet.Tables[0];

            }

            ToPdf f = new ToPdf("Отчет 1.pdf", dg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClass s = new DataClass();
            connection = new SqlConnection(s.ConnectionString());
            connection.Open();
            _userSet = new DataSet();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                _adapter = new SqlDataAdapter("SELECT \r\n    Customers.CustomerID,\r\n    Customers.FirstName,\r\n    Customers.LastName,\r\n    Customers.Patronymic,\r\n    Customers.Phone,\r\n    CategoryName,\r\n    Products.ProductName AS \"Имя продукта\",\r\n    SUM(Quantity) AS \"Количество\",\r\n    Price AS \"Цена\",\r\n    SUM(UnitPrice) AS \"Общая Сумма\"\r\nFROM \r\n    OrderDetails \r\nJOIN Orders ON OrderDetails.OrdersID = Orders.OrderID\r\nJOIN Customers ON Orders.CustomerID = Customers.CustomerID\r\nJOIN Products ON Products.ProductID = OrderDetails.ProductID\r\nJOIN Models ON Products.ModelID = Models.Id\r\nJOIN Categories ON Models.CategoryID = Categories.CategoryID\r\nGROUP BY \r\n    Customers.CustomerID,\r\n    Customers.FirstName,\r\n    Customers.LastName,\r\n    Customers.Patronymic,\r\n    Customers.Phone,\r\n    CategoryName,\r\n    Products.ProductName,\r\n    Price\r\nORDER BY\r\n    Customers.CustomerID,\r\n    CategoryName;\r\n", connection);
                _adapter.Fill(_userSet);
                dg.DataSource = _userSet.Tables[0];

            }

        }
    }
}

