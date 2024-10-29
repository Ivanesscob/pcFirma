using System;
using System.Windows.Forms;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;
using System.Data;

namespace PcFirma
{   

    public partial class RgisterForm : Form
    {
        private DataSet _userSet;
        private SqlDataAdapter _adapter;

        public RgisterForm(DataSet _userSet, SqlDataAdapter _adapter)
        {
            this._userSet = _userSet;
            this._adapter = _adapter;
            InitializeComponent();
            PasswordText.PasswordChar = '*';
        }

        private void backButton_Click(object sender, EventArgs e)
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
            if (String.IsNullOrEmpty(LoginText.Text) || String.IsNullOrEmpty(PasswordText.Text) ||
                String.IsNullOrEmpty(PhoneText.Text) || String.IsNullOrEmpty(EmailText.Text) || !mozno || !moznoEmail || !moznoPhone)
            {
                StatusPol.Text = "Fill all fields";
                StatusPol.Visible = true;
                if (!mozno) { StatusPol.Text = "A user with this login already exists"; }
                if (!moznoEmail) { StatusPol.Text = "A user with this email already exists"; }
                if (!moznoPhone) { StatusPol.Text = "A user with this phone already exists"; }
            }
            else if (!(IsValidEmail(EmailText.Text)))
            {
                StatusPol.Text = "Invalid Email";
                StatusPol.Visible = true;
            }
            else
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                baclButton.Visible = true;
                nextButton.Visible = false;
                ButtonReg.Visible = true;
                StatusPol.Visible = false;
            }
            
        }

        private void baclButton_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            baclButton.Visible = false;
            groupBox2.Visible = false;
            nextButton.Visible = true;
            ButtonReg.Visible = false;
        }

        private void ButtonReg_Click(object sender, EventArgs e)
        {
            

            
            DateTime selectedDate = BirthDayPicker.Value;
            DateTime sixteenYearsAgo = DateTime.Now.AddYears(-14);
            if (String.IsNullOrEmpty(LoginText.Text) || String.IsNullOrEmpty(PasswordText.Text) ||
                String.IsNullOrEmpty(PhoneText.Text) || String.IsNullOrEmpty(EmailText.Text) ||
                String.IsNullOrEmpty(NameText.Text) || String.IsNullOrEmpty(LastNameText.Text))
            {
                StatusPol.Text = "Fill all fields";
                StatusPol.Visible = true;
                
            }
            else if(selectedDate > sixteenYearsAgo)
            {
                StatusPol.Text = "You need to be over 14 years old";
                StatusPol.Visible = true;
            }
            else
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
                _userSet.Tables[0].Rows.Add(newRow);
                SaveData();
                MessageBox.Show("You have successfully registered");
                Close();
            }
        }
        private void SaveData()
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(_adapter);
            _adapter.Update(_userSet);
        }
    }
}
