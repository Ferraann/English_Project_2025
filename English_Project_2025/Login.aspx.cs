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

        // Evento al hacer click en el boton de login
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Pilla el email y la contraseña de los inputs
            // Trim() es para quitar espacios en blanco al principio y al final
            string email = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            
            try
            {
                // Path to the SQLite database
                string BDpath = Server.MapPath("~/bin/users.db");

                // Variables para guardar los datos del usuario, en null
                string userId = null;
                string name = null;
                string surname = null;
                string dob = null;
                string address = null;
                string mobile = null;
                string profile = null;
                // Comprobador de si se ha encontrado el usuario
                bool userFound = false;

                // Create and open a connection to the database
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    // Connect to the database
                    conn.Open();

                    // Coger los datos del usuario que coincidan con el email y la contraseña introducidos
                    string query = "SELECT id, profile, name, surname, DOB, address, mobile FROM users WHERE email = @email AND password = @password";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        // Datos del usuario introducidos en los inputs
                        comm.Parameters.AddWithValue("@email", email);
                        comm.Parameters.AddWithValue("@password", password);

                        using (SQLiteDataReader reader = comm.ExecuteReader())
                        {
                            // Si encuentra un registro que coincida con el email y la contraseña, se guardan los datos en las variables
                            if (reader.Read())
                            {
                                // Guardar los datos del usaurio recogidos por el reader en las variables creadas
                                userId = reader["id"].ToString();
                                name = reader["name"].ToString();
                                surname = reader["surname"].ToString();
                                dob = reader["DOB"].ToString();
                                address = reader["address"].ToString();
                                mobile = reader["mobile"].ToString();
                                profile = reader["profile"].ToString();
                                // Como SI hay usuario, cambiamos el valor de userFound de false a true
                                userFound = true;
                            }
                        }

                        // Si la variable userFound es true (SI hay usaurio) se ejecuta el if, si no, se ejecuta el else
                        if (userFound)
                        {
                            // Creamos un objeto de la clase User con los datos guardados
                            User user = new User(name, surname, dob, address, mobile, email, password, profile);

                            // Guardamos los datos en la sesion, PARA USARLOS EN OTRAS PAGINAS
                            Session["UserID"] = userId;
                            Session["Name"] = name;
                            Session["Surname"] = surname;
                            Session["DOB"] = dob;
                            Session["Address"] = address;
                            Session["Mobile"] = mobile;
                            Session["Email"] = email;
                            Session["Password"] = password;
                            Session["Profile"] = profile;

                            // REDIRECCIÓN A DEPENDIENDO DEL PERFIL
                            // Si el perfil es recepcionist...
                            if (user.Profile == "recepcionist")
                            {
                                // ... mandamos a Recepcionist.aspx.
                                Response.Redirect("Recepcionist.aspx");
                            }
                            // Si el perfil es client...
                            else if (user.Profile == "client")
                            {
                                // ... mandamos a Client.aspx
                                Response.Redirect("Client.aspx");
                            }
                            // SI no es ninguno de los dos...
                            else
                            {
                                // ... mensaje de error.
                                LabelMessage.Text = "Perfil desconocido.";
                            }
                        }
                        // Si no se ha encontrado el usuario...
                        else
                        {
                            // ... mensaje de error
                            LabelMessage.Text = "Usuario o contraseña incorrectos.";
                        }
                    }
                    // Cerramos la conexion
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
