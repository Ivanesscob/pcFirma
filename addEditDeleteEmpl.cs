﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PcFirma
{

    public partial class addEditDeleteEmpl : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        private int itemId;

        private DataSet _userSetForDic;
        private SqlDataAdapter _adapterForDic;

        private Dictionary<string, int> categories = new Dictionary<string, int>();
        public addEditDeleteEmpl(int id, DataSet dataset, SqlDataAdapter adapter, SqlConnection connection)
        {
            InitializeComponent();
            ControlBox = false;
            _userSet = dataset;
            _adapter = adapter;
            this.connection = connection;
            itemId = id;
            addButton.Text = itemId != -1 ? "Редактировать" : "Добавить";
            PasswordText.PasswordChar = '*';
            label1.Text = "Добавить сотрудников";
            

            _userSetForDic = new DataSet();
            string selectCategories = "SELECT * FROM JobTitles";
            _adapterForDic = new SqlDataAdapter(selectCategories, connection);
            _adapterForDic.Fill(_userSetForDic);

            foreach (DataRow categoryRow in _userSetForDic.Tables[0].Rows)
            {
                categories.Add(categoryRow["JobTitle"].ToString(),
                    Convert.ToInt32(categoryRow["JobTitleID"]));
            }
            comboBox1.DataSource = categories.Keys.ToList();

            if (itemId != -1)
            {
                label1.Text = "Редактировать сотрудников";
                var row = _userSet.Tables[0].Rows[itemId];
                LoginText.Text = row["Login"].ToString();
                PasswordText.Text = row["Password"].ToString();
                EmailText.Text = row["Email"].ToString();
                PhoneText.Text = row["Phone"].ToString();
                NameText.Text = row["FirstName"].ToString();
                LastNameText.Text = row["LastName"].ToString();
                PatrText.Text = row["Patronymic"].ToString();
                BirthDayPicker.Text = row["BirthDay"].ToString();
                comboBox1.SelectedIndex =int.Parse( row["JobTitleID"].ToString()) -1 ;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            DateTime selectedDate = BirthDayPicker.Value;
            DateTime sixteenYearsAgo = DateTime.Now.AddYears(-14);
            if (String.IsNullOrEmpty(LoginText.Text) || String.IsNullOrEmpty(PasswordText.Text) ||
                String.IsNullOrEmpty(PhoneText.Text) || String.IsNullOrEmpty(EmailText.Text) ||
                String.IsNullOrEmpty(NameText.Text) || String.IsNullOrEmpty(LastNameText.Text))
            {
                StatusPol.Text = "Заполни все поля!";
                StatusPol.Visible = true;
                
            }
            else if (selectedDate > sixteenYearsAgo)
            {
                StatusPol.Text = "Ты не должен быть моложе 14 лет!";
                StatusPol.Visible = true;
            }
            else
            {
                if (itemId == -1)
                {
                    
                    DataRow newRow = _userSet.Tables[0].NewRow();
                    newRow["Login"] = LoginText.Text;
                    newRow["Password"] = PasswordText.Text;
                    newRow["Email"] = EmailText.Text;
                    newRow["Phone"] = PhoneText.Text;
                    newRow["FirstName"] = NameText.Text;
                    newRow["LastName"] = LastNameText.Text;
                    newRow["Patronymic"] = PatrText.Text;
                    newRow["BirthDay"] = BirthDayPicker.Text;
                    newRow["JobTitleID"] = categories[comboBox1.Text].ToString();
                    _userSet.Tables[0].Rows.Add(newRow);
                    SaveData();
                    MessageBox.Show("Вы успешно добавили запись");
                    
                }
                else
                {
                    
                    var row = _userSet.Tables[0].Rows[itemId];
                    row["Login"] = LoginText.Text;
                    row["Password"] = PasswordText.Text;
                    row["Email"] = EmailText.Text;
                    row["Phone"] = PhoneText.Text;
                    row["FirstName"] = NameText.Text;
                    row["LastName"] = LastNameText.Text;
                    row["Patronymic"] = PatrText.Text;
                    row["BirthDay"] = BirthDayPicker.Text;
                    row["JobTitleID"] = categories[comboBox1.Text].ToString();
                    SaveData();
                    MessageBox.Show("Вы успешно редактировали запись");
                }
                Close();
                
            }
        }
        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
        }

        private void baclButton_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            baclButton.Visible = false;
            groupBox2.Visible = false;
            nextButton.Visible = true;
            addButton.Visible = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            bool mozno = true;
            bool moznoEmail = true;
            bool moznoPhone = true;
            foreach (DataRow row in _userSet.Tables[0].Rows)
            {

                if (row["Login"].ToString() == LoginText.Text)
                {
                    mozno = false;
                }
            }
            foreach (DataRow row1 in _userSet.Tables[0].Rows)
            {
                if (row1["Email"].ToString() == EmailText.Text)
                {
                    moznoEmail = false;
                }
            }
            foreach (DataRow row1 in _userSet.Tables[0].Rows)
            {
                if (row1["Phone"].ToString() == PhoneText.Text)
                {
                    moznoPhone = false;
                }
            }
            if (itemId != -1)
            {
                mozno = true;
                moznoPhone = true;
                moznoEmail = true;
            }
            if (String.IsNullOrEmpty(LoginText.Text) || String.IsNullOrEmpty(PasswordText.Text) ||
                String.IsNullOrEmpty(PhoneText.Text) || String.IsNullOrEmpty(EmailText.Text) || !mozno || !moznoEmail || !moznoPhone)
            {
                StatusPol.Text = "Заполни все поля!";
                StatusPol.Visible = true;
                if (!mozno) { StatusPol.Text = "Пользователь с таким логином уже существует"; }
                if (!moznoEmail) { StatusPol.Text = "Пользователь с такой почтой уже существует"; }
                if (!moznoPhone) { StatusPol.Text = "Пользователь с таким телофоном уже существует"; }
            }
            else if (!(IsValidEmail(EmailText.Text)))
            {
                StatusPol.Text = "Несуществующая почта";
                StatusPol.Visible = true;
            }
            else
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                baclButton.Visible = true;
                nextButton.Visible = false;
                addButton.Visible = true;
                StatusPol.Visible = false;
            }
        }

        
    }
}
