using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace English_Project_2025
{
    public class Reservation
    {
        // Properties
        public int id_reservation { get; set; }

        // Foreign Key --> Corresponds to User.id_user. Es un valor de la tabla Users
        // Sirve para relacionar la reserva con el usuario que la hizo. Tienes los datos de la reserva y un id de usuario, miras el id a que usuario pertenece
        // y ahí tienes todos los datos del usuario que hizo la reserva.
        public int id_user { get; set; }
        public string check_in_date { get; set; }
        public string check_out_date { get; set; }
        public string type_of_room { get; set; }
        public double total_cost { get; set; }

        // Constructor
        public Reservation(int id_user, string check_in_date, string check_out_date, string type_of_room, double total_cost)
        {
            this.id_user = id_user;
            this.check_in_date = check_in_date;
            this.check_out_date = check_out_date;
            this.type_of_room = type_of_room;
            this.total_cost = total_cost;
        }

        public static void AddReservation(Reservation reservation)
        {
            try
            {
                // Path to the SQLite database
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                // Create and open a connection to the database
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    // Connect to the database
                    conn.Open();

                    // Añadir a la tabla reservations, los valores de la reserva (@id_user, @check_in_date, @check_out_date, @type_of_room, @total_cost)";
                    // ERROR: no se deberia poner el id_user porque el admin no lo deberia de conocer, deberiamos haber usado el email y llamar al metodo GetUserByEmail
                    string query = @"INSERT INTO reservations 
                                    (id_user, check_in_date, check_out_date, type_of_room, total_cost)
                                     VALUES 
                                    (@id_user, @check_in_date, @check_out_date, @type_of_room, @total_cost)";

                    // Valores de la reserva
                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@id_user", reservation.id_user);
                        comm.Parameters.AddWithValue("@check_in_date", reservation.check_in_date);
                        comm.Parameters.AddWithValue("@check_out_date", reservation.check_out_date);
                        comm.Parameters.AddWithValue("@type_of_room", reservation.type_of_room);
                        comm.Parameters.AddWithValue("@total_cost", reservation.total_cost);

                        // ExecuteNonQuery() se utiliza para ejecutar comandos SQL que realizan cambios en la base de datos pero no devuelven una tabla de datos (como una lista de usuarios).
                        // Usas ExecuteNonQuery() cuando quieres darle una orden a la base de datos para que haga un cambio y solo te interesa saber si se hizo correctamente.
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding reservation: " + ex.Message);
            }
        }


        public static void UpdateReservation(Reservation reservation)
        {
            try
            {
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    // Update the reservation details based on id_reservation
                    // Modifica de la tabla de reservations, los valores de check_in_date, check_out_date, type_of_room, total_cost que coincidan con el id_reservation
                    string query = @"UPDATE reservations SET
                                        check_in_date = @check_in_date,
                                        check_out_date = @check_out_date,
                                        type_of_room = @type_of_room,
                                        total_cost = @total_cost
                                     WHERE id_reservation = @id_reservation";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@check_in_date", reservation.check_in_date);
                        comm.Parameters.AddWithValue("@check_out_date", reservation.check_out_date);
                        comm.Parameters.AddWithValue("@type_of_room", reservation.type_of_room);
                        comm.Parameters.AddWithValue("@total_cost", reservation.total_cost);
                        comm.Parameters.AddWithValue("@id_reservation", reservation.id_reservation);

                        comm.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating reservation: " + ex.Message);
            }
        }

        public static void DeleteReservation(int id_reservation)
        {
            try
            {
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    string query = "DELETE FROM reservations WHERE id_reservation = @id_reservation";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@id_reservation", id_reservation);
                        comm.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting reservation: " + ex.Message);
            }
        }

        // Devuelve una List<Reservation>
        // Se le pasa como parametro un userId (int)
        public static List<Reservation> GetReservationsByUser(int userId)
        {
            // Crear una lista vacia de reservas
            List<Reservation> list = new List<Reservation>();

            string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
            {
                conn.Open();

                // Selecciona todas las reservas que coincidan con el id_user
                string query = "SELECT id_reservation, check_in_date, check_out_date, type_of_room, total_cost FROM reservations WHERE id_user = @userId";

                using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                {
                    // parametro @userId
                    comm.Parameters.AddWithValue("@userId", userId);

                    using (SQLiteDataReader reader = comm.ExecuteReader())
                    {
                        // Read() avanza al siguiente registro en el conjunto de resultados
                        // Va devoliendo true mientras haya registros para leer
                        // sirve para iterar sobre los resultados de una consulta SQL y mostrar todas las reservas que coincidan con el id_user
                        // Mientras haya registros, crea un objeto Reservation con los datos del registro actual y lo añade a la lista
                        while (reader.Read())
                        {
                            Reservation r = new Reservation(
                                userId,
                                reader["check_in_date"].ToString(),
                                reader["check_out_date"].ToString(),
                                reader["type_of_room"].ToString(),
                                Convert.ToDouble(reader["total_cost"])
                            );

                            r.id_reservation = Convert.ToInt32(reader["id_reservation"]);

                            list.Add(r);
                        }
                    }
                }

                conn.Close();
            }

            return list;
        }

    }
}