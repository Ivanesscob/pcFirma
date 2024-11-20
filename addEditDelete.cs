using System;
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
    public partial class addEditDelete : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;
        private SqlConnection connection;
        private int itemId;
        public addEditDelete(int id, DataSet dataset, SqlDataAdapter adapter, SqlConnection connection)
        {
            InitializeComponent();
            _userSet = dataset;
            ControlBox = false;
            _adapter = adapter;
            itemId = id;
            this.connection = connection;
            addButton.Text = itemId != -1 ? "Редактировать" : "Добавить";

            if (itemId != -1)
            {
                var row = _userSet.Tables[0].Rows[itemId];
                NameText.Text = row["Name"].ToString();
                PhoneText.Text = row["Phone"].ToString();
                EmailText.Text = row["Email"].ToString();
                AddressText.Text = row["Address"].ToString();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            if (itemId == -1)
            {

                bool mozno = true;
                bool moznoEmail = true;


                DataRow newRow = _userSet.Tables[0].NewRow();

                foreach (DataRow row1 in _userSet.Tables[0].Rows)
                {
                    if (row1["Phone"].ToString() == PhoneText.Text)
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
                if (!mozno) { MessageBox.Show("Покупатель с таким телефоном уже существует"); }
                if (!moznoEmail) { MessageBox.Show("Покупатель с такой почтой уже существует"); }

                if ((String.IsNullOrWhiteSpace(NameText.Text) || String.IsNullOrWhiteSpace(PhoneText.Text) || String.IsNullOrWhiteSpace(EmailText.Text) || String.IsNullOrWhiteSpace(AddressText.Text)))
                {
                    MessageBox.Show("Заполните все поля");
                }
                else if (!(IsValidEmail(EmailText.Text)))
                {
                    MessageBox.Show( "Несуществующая почта");
                    
                }
                else
                {
                    if (mozno && moznoEmail)
                    {
                        var row = _userSet.Tables[0].NewRow();
                        row["Name"] = NameText.Text;
                        row["Phone"] = PhoneText.Text;
                        row["Email"] = EmailText.Text;
                        row["Address"] = AddressText.Text;
                        _userSet.Tables[0].Rows.Add(row);
                        SaveData();
                        Close();
                    }
                }
            }
            else
            {


                if ((String.IsNullOrWhiteSpace(NameText.Text) || String.IsNullOrWhiteSpace(PhoneText.Text) || String.IsNullOrWhiteSpace(EmailText.Text) || String.IsNullOrWhiteSpace(AddressText.Text)))
                {
                    MessageBox.Show("Заполните все поля");
                }
                else if (!(IsValidEmail(EmailText.Text)))
                {
                    MessageBox.Show("Несуществующая форма");

                }
                else
                {
                    var row = _userSet.Tables[0].Rows[itemId];
                    row["Name"] = NameText.Text;
                    row["Phone"] = PhoneText.Text;
                    row["Email"] = EmailText.Text;
                    row["Address"] = AddressText.Text;
                    SaveData();
                    Close();
                }
            }
            
        }
        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
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
    }
}
