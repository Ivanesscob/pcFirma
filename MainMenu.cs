using System;
using System.Windows.Forms;

namespace PcFirma
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
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
    }
}
