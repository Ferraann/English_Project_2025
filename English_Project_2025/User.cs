using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace English_Project_2025
{
    public class User
    {
        // Properties i Getters i Setters
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
            // El try catch es para manejar errores. Si hay un error en el bloque try, se captura en el catch.
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
                    // Insertar dentro de la tabla de users estos valores (@name, @surname, @DOB, @address, @mobile, @email, @password, @profile).
                    // El orden importa.
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
                    // Abrir la conexión
                    conn.Open();

                    // Consulta SQL para actualizar un usuario existente
                    // Pones los datos y luego el WHERE para indicar que usuario quieres actualizar (el que tenga ese Id_user).
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

                    // Comando SQL para ejecutar la consulta
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
                throw new Exception("Error updating user: " + ex.Message);
            }
        }

        // Método para eliminar un usuario por su Id_user
        public static void DeleteUser(int id_user)
        {
            try
            {
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    // Eliminar de la tabla users el usuario cuyo Id_user coincida con el proporcionado
                    string query = "DELETE FROM users WHERE Id_user = @id_user";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        // id que se proporciona
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

        // Método para obtener un usuario por su email
        public static User GetUserByEmail(string email)
        {
            // Inicializa un objeto User como null
            User user = null;

            try
            {
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    // Selecciona los campos del usuario donde el email coincida con el proporcionado
                    string query = @"SELECT id, name, surname, DOB, address, mobile, email, password, profile 
                                     FROM users 
                                     WHERE email = @email";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        // Email proporcionado
                        comm.Parameters.AddWithValue("@email", email);

                        // Ejecuta la consulta y obtiene un lector de datos
                        // El reader (que es un objeto de tipo SQLiteDataReader) actúa como un puntero o cursor inteligente que recorre los resultados que te
                        // devolvió la base de datos tras hacer el SELECT. ---> @"SELECT id, name, surname, DOB, address, mobile, email, password, profile 
                        using (SQLiteDataReader reader = comm.ExecuteReader())
                        {
                            // Si hay un registro (usuario) que coincide con el email proporcionado se asignan al objeto user los valores obtenidos de la
                            // base de datos
                            if (reader.Read())
                            {
                                user = new User(
                                    // Hemos puesto en cada caso el convert toint y el to string para asegurarnos que los datos se asignan correctamente
                                    // (es del tipo que queremos)
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
            // SI no ha encontrado ningun error devuelve el usuario con los datos (o null si no se encontró)
            return user;
        }
    }
}