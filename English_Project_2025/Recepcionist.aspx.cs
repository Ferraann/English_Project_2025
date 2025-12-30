using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            // Restablece el texto
            LabelMessage.Text = "";
            // Color inicial --> rojo
            LabelMessage.ForeColor = System.Drawing.Color.Red;

            // Pillamos el texto introducido en los inputs
            string nameField = NameTextBox.Text.Trim();
            string surnameField = SurnameTextBox.Text.Trim();
            string DOBField = DOBTextBox.Text.Trim();
            string phoneField = PhoneTextBox.Text.Trim();
            string addressField = AddressTextBox.Text.Trim();
            string profileField = ProfileTextBox.Text.Trim();
            string emailField = EmailTextBox.Text.Trim();
            string passwordField = PasswordTextBox.Text.Trim();


            try
            {
                // Ruta a la bbdd
                string BDpath = Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    // Abrimos conexion
                    conn.Open();

                    // Creamos un usuario con los valores
                    User user = new User(nameField, surnameField, DOBField, addressField, phoneField,
                                 emailField, passwordField, profileField);

                    // Llamamos al metodo AddUser de la clase user y le pasamos el usuario creado
                    user.AddUser(user);

                    // Reestablecer el texto de los inputs a un texto vacío
                    NameTextBox.Text = "";
                    SurnameTextBox.Text = "";
                    DOBTextBox.Text = "";
                    PhoneTextBox.Text = "";
                    AddressTextBox.Text = "";
                    ProfileTextBox.Text = "";
                    EmailTextBox.Text = "";
                    PasswordTextBox.Text = "";

                    // Mensaje de éxito con color verde
                    LabelMessage.Text = "User added successfully!";
                    LabelMessage.ForeColor = System.Drawing.Color.Green;

                    // Cerramos la conexion
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "Adding user failed: " + ex.Message;
                LabelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void searchBtn_Click(object sender, EventArgs e)
        {
            // Pillamos el email introducido
            string searchEmail = searcherTextBox.Text.Trim();
            // Mensaje vacio de momento
            LabelMessage.Text = "";

            // Metemos un display none a todo el contenido restante del div (de momento no hay datos del usuario)
            // Ocultamos el titulo de la pagina, cada apartado (nombre, apellido, ...), el título de mis reservas y todas las reservas del usuario
            H2SectionTitle.Style["display"] = "none";
            H2ReservationsTitle.Style["display"] = "none";
            PanelUserInfo.Style["display"] = "none";
            PanelReservations.Style["display"] = "none";
            ReservationsContainer.InnerHtml = string.Empty;

            // Si el email esta vacio o es null...
            if (string.IsNullOrEmpty(searchEmail))
            {
                // ... error y return
                LabelMessage.Text = "Please enter an email address to search.";
                return;
            }

            try
            {
                // Crea un objeto User llamando al metodo GetUserByEmail y le pasa el email introducido
                User foundUser = English_Project_2025.User.GetUserByEmail(searchEmail);

                // Si encuentra un usuario con ese email...
                if (foundUser != null)
                {
                    // ... muestra sus datos en las labels correspondientes
                    LabelClientName.Text = foundUser.Name;
                    LabelClientSurname.Text = foundUser.Surname;
                    LabelClientDOB.Text = foundUser.DOB;
                    LabelClientPhone.Text = foundUser.Mobile;
                    LabelClientAddress.Text = foundUser.Address;
                    LabelClientEmail.Text = searchEmail;

                    // Pillas el id para poder coger las reservas del usuario
                    int userId = foundUser.Id_user;

                    // Llamamos al metodo GetReservationsByUser para coger las reservas del usuario
                    List<Reservation> userReservations = English_Project_2025.Reservation.GetReservationsByUser(userId);

                    // Creador del html
                    StringBuilder html = new StringBuilder();

                    // SI no es null o si el tamaño de la lista es mayor que 0...
                    if (userReservations != null && userReservations.Count > 0)
                    {
                        // ... recorremos la lista de reservas y creamos el html para mostrar la reserva
                        foreach (var r in userReservations)
                        {
                            // div con una clase y p con strong y el titulo de la p y el dato de la reserva, ejemplo: {r.check_in_date}.
                            html.Append("<div class='reservation-card'>");
                            html.Append($"<p><strong>ID Reservation:</strong> {r.id_reservation}</p>");
                            html.Append($"<p><strong>Check-in:</strong> {r.check_in_date}</p>");
                            html.Append($"<p><strong>Check-out:</strong> {r.check_out_date}</p>");
                            html.Append($"<p><strong>Room type:</strong> {r.type_of_room}</p>");
                            html.Append($"<p><strong>Total cost:</strong> {r.total_cost}€</p>");
                            html.Append("</div>");
                        }
                    }
                    else
                    {
                        // Si la lista en null o no hay reservas, muestra este mensaje
                        html.Append("<p>This user has no active reservations.</p>");
                    }

                    // Añadir este html creado a un div con este id: ReservationsContainer.
                    ReservationsContainer.InnerHtml = html.ToString();

                    // Volvemos a mostrar el contenido oculto
                    PanelUserInfo.Style["display"] = "grid";
                    H2SectionTitle.Style["display"] = "block";
                    H2ReservationsTitle.Style["display"] = "block";
                    PanelReservations.Style["display"] = "block";

                    // Mensaje de que se han encontrado datos del usuario
                    LabelMessage.Text = $"User '{foundUser.Name} {foundUser.Surname}' found. Showing {userReservations.Count} reservations.";
                }
                else
                {
                    // Mensaje de usaurio no encontrado
                    LabelMessage.Text = $"No user found with email: {searchEmail}";
                }
            }
            catch (Exception ex)
            {
                // Mensajes de error
                LabelMessage.Text = "Search failed due to a database error: " + ex.Message;
                H2SectionTitle.Style["display"] = "none";
                H2ReservationsTitle.Style["display"] = "none";
                PanelUserInfo.Style["display"] = "none";
                PanelReservations.Style["display"] = "none";
            }
        }
    }
}