﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
            this.id = id; ControlBox = false;

            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.MeasureItem += ListBox1_MeasureItem;
            listBox1.DrawItem += ListBox1_DrawItem;

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
        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {

            e.ItemHeight = 50;
        }

        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;


            string itemText = listBox1.Items[e.Index].ToString();


            e.DrawBackground();


            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }


            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;


                using (Brush textBrush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds, stringFormat);
                }
            }



            e.Graphics.DrawRectangle(Pens.Gray, e.Bounds);


            e.DrawFocusRectangle();
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

                _adapter = new SqlDataAdapter("select * from OrderDetails join Orders on Orders.OrderID = OrderDetails.OrdersID  join Products on Products.ProductID = OrderDetails.ProductID where CustomerID = " + id.ToString(), connection);
                _adapter.Fill(_userSet);

            }
            string a = "";
            string idOrd = _userSet.Tables[0].Rows[0]["OrderID"].ToString();
            foreach(DataRow row in _userSet.Tables[0].Rows)
            {
                if (row["OrdersID"].ToString() == idOrd)
                {
                    a += row["ProductName"].ToString();      
                }
                else
                {
                    listBox1.Items.Add(a);
                    idOrd = row["OrdersID"].ToString();
                    a = row["ProductName"].ToString();
                }
            }
            listBox1.Items.Add(a);
            

        }
       
    }
}
