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
            try
            {
                string BDpath = "C:\\Users\\Usuario\\source\\repos\\English_Project_2025\\English_Project_2025\\bin\\users.db";
                string username = UsernameTextBox.Text.Trim();
                string password = PasswordTextBox.Text.Trim();

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    string query = "SELECT profile FROM users WHERE username = @username AND password = @password";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@username", username);
                        comm.Parameters.AddWithValue("@password", password);

                        // Uso de ExecuteScalar() para obtener un único valor (profile).
                        object result = comm.ExecuteScalar();

                        if (result != null)
                        {
                            string profile = result.ToString();

                            if (profile.Equals("recepcionista"))
                            {
                                Response.Redirect("Recepcionista.aspx");
                            }
                            else if (profile.Equals("cliente"))
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
                            LabelMessage.ForeColor = System.Drawing.Color.Red;
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