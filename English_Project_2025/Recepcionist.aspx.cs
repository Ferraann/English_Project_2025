using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace English_Project_2025
{
    public partial class Recepcionista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                LabelName.Text = Session["Name"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string BDpath = Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    string nameField = NameTextBox.Text;
                    string surnameField = SurnameTextBox.Text;
                    string DOBField = DOBTextBox.Text.ToString();
                    string phoneField = PhoneTextBox.Text.ToString();
                    string addressField = AddressTextBox.Text.ToString();
                    string profileField = ProfileTextBox.Text.ToString();
                    string emailField = EmailTextBox.Text.ToString();
                    string passwordField = PasswordTextBox.Text.ToString();


                    User user = new User(nameField, surnameField, DOBField, addressField, phoneField,
                                emailField, passwordField, profileField);

                    user.AddUser(user);

                    NameTextBox.Text = "";
                    SurnameTextBox.Text = "";
                    DOBTextBox.Text = "";
                    PhoneTextBox.Text = "";
                    AddressTextBox.Text = "";
                    ProfileTextBox.Text = "";
                    EmailTextBox.Text = "";
                    PasswordTextBox.Text = "";

                    LabelMessage.Text = "User added";

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "Adding user failed: " + ex.Message;
            }
        }

        public void SearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}