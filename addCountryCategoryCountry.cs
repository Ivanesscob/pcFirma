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
using System.Windows.Forms;

namespace PcFirma
{
    public partial class addCountryCategoryCountry : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;

        private int status;

        private DataSet _userSetForDic;
        private SqlDataAdapter _adapterForDic;

        

        private Dictionary<string, int> categories = new Dictionary<string, int>();
        public addCountryCategoryCountry(int a, DataSet dataset, SqlDataAdapter adapter, SqlConnection connection)
        {
            status = a;
            _userSet = dataset;
            _adapter = adapter;
            this.connection = connection;

            InitializeComponent();
            switch (status)
            {
                case 0:
                    nameOfAdd.Text = "Add country";
                    break;
                case 1:
                    nameOfAdd.Text = "Add brand";
                    groupBox2.Visible=true;
                    groupBox3.Visible=true;

                    _userSetForDic = new DataSet();
                    string selectCategories = "SELECT * FROM Counrties";
                    _adapterForDic = new SqlDataAdapter(selectCategories, connection);
                    _adapterForDic.Fill(_userSetForDic);

                    foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
                    {
                        categories.Add(categoryRow["Country"].ToString(),
                            Convert.ToInt32(categoryRow["Id"]));
                    }
                    comboBox1.DataSource = categories.Keys.ToList();


                    break ;
                case 2:
                    nameOfAdd.Text = "Add category";
                    break ;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            switch (status)
            {
                case 0:
                    FillData("Country");
                    break;
                case 1:
                    bool mozno = false;
                    foreach (DataRow row1 in _userSet.Tables[0].Rows)
                    {
                        if (row1["Brand"].ToString() == textBox2.Text)
                        {
                            mozno = true;
                        }
                    }
                    if (String.IsNullOrEmpty(textBox2.Text))
                    {
                        StatusPol.Text = "Fill all fields";
                    }
                    else if (mozno)
                    {
                        StatusPol.Text = "This entry already exists";
                    }
                    else
                    {
                        var row2 = _userSet.Tables[0].NewRow();
                        row2["Brand"] = textBox2.Text;
                        row2["CountryID"] = categories[comboBox1.Text];
                        _userSet.Tables[0].Rows.Add(row2);
                        SaveData();
                        MessageBox.Show("You have successfully add");
                        Close();
                    }
                    break;
                case 2:
                    FillData("CategoryName");
                    break;
            }
        }
        private void FillData(string s)
        {
            bool mozno = false;
            foreach (DataRow row1 in _userSet.Tables[0].Rows)
            {
                if (row1[s].ToString() == textBox1.Text)
                {
                    mozno = true;
                }
            }
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                StatusPol.Text = "Fill all fields";
            }
            else if (mozno)
            {
                StatusPol.Text = "This entry already exists";
            }
            else
            {
                var row2 = _userSet.Tables[0].NewRow();
                row2[s] = textBox1.Text;
                _userSet.Tables[0].Rows.Add(row2);
                SaveData();
                MessageBox.Show("You have successfully add");
                Close();
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
        }
    }
}