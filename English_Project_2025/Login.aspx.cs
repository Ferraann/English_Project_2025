using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            try
            {
                string BDpath = Server.MapPath("~/English_Project_2025/App_Data/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    string query = "SELECT profile FROM users WHERE username = @username AND password = @password";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@username", username);
                        comm.Parameters.AddWithValue("@password", password);

                        object result = comm.ExecuteScalar();

                        if (result != null)
                        {
                            string profile = result.ToString();

                            User user = new User(username, password, profile);

                            if (user.Profile == "recepcionista")
                            {
                                Response.Redirect("Recepcionista.aspx");
                            }
                            else if (user.Profile == "cliente")
                            {
                                Response.Redirect("Cliente.aspx");
                            }
                            else
                            {
                                LabelMessage.ForeColor = System.Drawing.Color.Orange;
                                LabelMessage.Text = "Perfil desconocido.";
                            }
                        }
                        else
                        {
                            LabelMessage.ForeColor = System.Drawing.Color.Orange;
                            LabelMessage.Text = "Invalid username or password.";
                        }

                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "An error occurred while connecting to the database.";
            }
        }
    }
}