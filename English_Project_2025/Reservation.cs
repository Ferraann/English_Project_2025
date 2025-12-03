using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace English_Project_2025
{
    public class Reservation
    {
        public int id_reservation { get; set; }
        public int id_user { get; set; }
        public string check_in_date { get; set; }
        public string check_out_date { get; set; }
        public string type_of_room { get; set; }
        public double total_cost { get; set; }

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
                string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    string query = @"INSERT INTO reservations 
                                    (id_user, check_in_date, check_out_date, type_of_room, total_cost)
                                     VALUES 
                                    (@id_user, @check_in_date, @check_out_date, @type_of_room, @total_cost)";

                    using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@id_user", reservation.id_user);
                        comm.Parameters.AddWithValue("@check_in_date", reservation.check_in_date);
                        comm.Parameters.AddWithValue("@check_out_date", reservation.check_out_date);
                        comm.Parameters.AddWithValue("@type_of_room", reservation.type_of_room);
                        comm.Parameters.AddWithValue("@total_cost", reservation.total_cost);

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

        public static List<Reservation> GetReservationsByUser(int userId)
        {
            List<Reservation> list = new List<Reservation>();

            string BDpath = HttpContext.Current.Server.MapPath("~/bin/users.db");

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
            {
                conn.Open();

                string query = "SELECT id_reservation, check_in_date, check_out_date, type_of_room, total_cost FROM reservations WHERE id_user = @userId";

                using (SQLiteCommand comm = new SQLiteCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@userId", userId);

                    using (SQLiteDataReader reader = comm.ExecuteReader())
                    {
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