using System;
using System.Windows.Forms;
using System.Drawing;
using System.Web;

namespace PcFirma
{
    public partial class MainMenu : Form
    {
        public MainMenu(int id)
        {
           

            InitializeComponent();
            if (id == 3) { groupBox1.Visible = false; }
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
    }
}
