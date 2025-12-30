using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace English_Project_2025
{
    public class User
    {
        // Atributos i Getters i Setters
        public int Id_user { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }

        // Constructor
        public User(string name, string surname, string dob, string address, string mobile, string email, string password, string profile)
        {
            Name = name;
            Surname = surname;
            DOB = dob;
            Address = address;
            Mobile = mobile;
            Email = email;
            Password = password;
            Profile = profile;
        }

        // Encadenamiento de Constructores
        // Permite crear un objeto User con Id_user, sin repetir codigo. Primero llama al constructor sin Id_user (principal) y si lo valida -> asigna Id_user.
        // : this(...): Llama a otro constructor de la misma clase.
        public User(int id_user, string name, string surname, string dob, string address, string mobile, string email, string password, string profile)
            : this(name, surname, dob, address, mobile, email, password, profile)
        {
            Id_user = id_user;
        }

        public void AddUser(User user) // Parameters
        {
            try
            {
                // Ruta de la base de datos. "HttpContext.Current.Server.MapPath" si nos pregunta porque lo hemos hecho así, le decimos que de la otra manera no funcionaba.
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                // conn = conexión a la base de datos SQLite
                // Esta parte es para hacer la conexion a la base de datos
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    // Abre la conexión
                    conn.Open();

                    // Consulta SQL para insertar un nuevo usuario
                    string query = @"INSERT INTO users 
                                        (name, surname, DOB, address, mobile, email, password, profile)
                                        VALUES 
                                        (@name, @surname, @DOB, @address, @mobile, @email, @password, @profile)";

                    // Comando SQL para ejecutar la consulta
                    // comm = comando SQL
                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        // Aqui pilla el valor de los parametros y los asigna a la consulta SQL
                        comm.Parameters.AddWithValue("@name", user.Name);
                        comm.Parameters.AddWithValue("@surname", user.Surname);
                        comm.Parameters.AddWithValue("@DOB", user.DOB);
                        comm.Parameters.AddWithValue("@address", user.Address);
                        comm.Parameters.AddWithValue("@mobile", user.Mobile);
                        comm.Parameters.AddWithValue("@email", user.Email);
                        comm.Parameters.AddWithValue("@password", user.Password);
                        comm.Parameters.AddWithValue("@profile", user.Profile);

                        // ExecuteNonQuery() se utiliza para ejecutar comandos SQL que realizan cambios en la base de datos pero no devuelven una tabla de datos (como una lista de usuarios).
                        // Usas ExecuteNonQuery() cuando quieres darle una orden a la base de datos para que haga un cambio y solo te interesa saber si se hizo correctamente.
                        comm.ExecuteNonQuery();
                    }

                    // Cierra la conexión
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Si hay un error, lanza una excepción con un mensaje descriptivo
                throw new Exception("Error adding user: " + ex.Message);
            }
        }


        public static void UpdateUser(User user)
        {
            try
            {
                // Ruta de la base de datos
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                // Conexión a la base de datos SQLite
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    string query = @"UPDATE users SET
                                         name = @name,
                                         surname = @surname,
                                         DOB = @DOB,
                                         address = @address,
                                         mobile = @mobile,
                                         email = @email,
                                         password = @password,
                                         profile = @profile
                                     WHERE Id_user = @id_user";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@name", user.Name);
                        comm.Parameters.AddWithValue("@surname", user.Surname);
                        comm.Parameters.AddWithValue("@DOB", user.DOB);
                        comm.Parameters.AddWithValue("@address", user.Address);
                        comm.Parameters.AddWithValue("@mobile", user.Mobile);
                        comm.Parameters.AddWithValue("@email", user.Email);
                        comm.Parameters.AddWithValue("@password", user.Password);
                        comm.Parameters.AddWithValue("@profile", user.Profile);
                        comm.Parameters.AddWithValue("@id_user", user.Id_user);

                        comm.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user: " + ex.Message);
            }
        }


        public static void DeleteUser(int id_user)
        {
            try
            {
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    string query = "DELETE FROM users WHERE Id_user = @id_user";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@id_user", id_user);

                        comm.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting user: " + ex.Message);
            }
        }


        public static User GetUserByEmail(string email)
        {
            User user = null;

            try
            {
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    string query = @"SELECT id, name, surname, DOB, address, mobile, email, password, profile 
                                     FROM users 
                                     WHERE email = @email";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@email", email);

                        using (SQLiteDataReader reader = comm.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User(
                                    Convert.ToInt32(reader["id"]),
                                    reader["name"].ToString(),
                                    reader["surname"].ToString(),
                                    reader["DOB"].ToString(),
                                    reader["address"].ToString(),
                                    reader["mobile"].ToString(),
                                    reader["email"].ToString(),
                                    reader["password"].ToString(),
                                    reader["profile"].ToString()
                                );
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user by email: " + ex.Message);
            }

            return user;
        }
    }
}