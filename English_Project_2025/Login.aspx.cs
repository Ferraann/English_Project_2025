using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace English_Project_2025
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            string dbPath = Server.MapPath("~/users.db");
            string connectionString = $"Data Source={dbPath};Version=3;";
            string query = "SELECT isDoctor, dni FROM users WHERE username = @Username AND password = @Password";

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int isDoctor = reader.GetInt32(0);
                                string dni = reader.GetString(1);

                                Session["username"] = username;
                                Session["password"] = password;
                                Session["dni"] = dni;

                                if (isDoctor == 1)
                                {
                                    Session["role"] = "Doctor";
                                    Response.Redirect("~/Doctor.aspx");
                                }
                                else
                                {
                                    Session["role"] = "Patient";
                                    Response.Redirect("~/Patient.aspx");
                                }
                            }
                            else
                            {
                                LabelMessage.Text = "Invalid username or password.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "An error occurred while connecting to the database.";
            }
        }
    }
}