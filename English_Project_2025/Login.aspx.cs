using System;
using System.Collections;
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
            string email = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            try
            {
                string BDpath = Server.MapPath("~/bin/users.db");

                string userId = null;
                string name = null;
                string surname = null;
                string dob = null;
                string address = null;
                string mobile = null;
                string profile = null;
                bool userFound = false;

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    string query = "SELECT id, profile, name, surname, DOB, address, mobile FROM users WHERE email = @email AND password = @password";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@email", email);
                        comm.Parameters.AddWithValue("@password", password);

                        using (SQLiteDataReader reader = comm.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = reader["id"].ToString();
                                name = reader["name"].ToString();
                                surname = reader["surname"].ToString();
                                dob = reader["DOB"].ToString();
                                address = reader["address"].ToString();
                                mobile = reader["mobile"].ToString();
                                profile = reader["profile"].ToString();
                                userFound = true;
                            }
                        }

                        if (userFound)
                        {
                            User user = new User(name, surname, dob, address, mobile, email, password, profile);

                            Session["UserID"] = userId;
                            Session["Name"] = name;
                            Session["Surname"] = surname;
                            Session["DOB"] = dob;
                            Session["Address"] = address;
                            Session["Mobile"] = mobile;
                            Session["Email"] = email;
                            Session["Password"] = password;
                            Session["Profile"] = profile;

                            if (user.Profile == "recepcionist")
                            {
                                Response.Redirect("Recepcionist.aspx");
                            }
                            else if (user.Profile == "client")
                            {
                                Response.Redirect("Client.aspx");
                            }
                            else
                            {
                                LabelMessage.Text = "Perfil desconocido.";
                            }
                        }
                        else
                        {
                            LabelMessage.Text = "Usuario o contraseña incorrectos.";
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "An error occurred while connecting to the database. Error: " + ex.Message;
            }
        }
    }
}
