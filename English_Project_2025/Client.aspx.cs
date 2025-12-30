using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace English_Project_2025
{
    public partial class Cliente : System.Web.UI.Page
    {
        // Primero que se inicia al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            // Comprobar si la session "Name" existe (si el usuario ha iniciado sesion)
            if (Session["Name"] != null)
            {
                LabelName.Text = Session["Name"].ToString();
                LabelClientName.Text = Session["Name"].ToString();
                LabelClientSurname.Text = Session["Surname"].ToString();
                LabelClientPhone.Text = Session["Mobile"].ToString();
                LabelClientEmail.Text = Session["Email"].ToString();
                LabelClientDOB.Text = Session["DOB"].ToString();
                LabelClientAddress.Text = Session["Address"].ToString();

                // Si es la primera vez que se carga la pagina hace esto...
                if (!IsPostBack)
                {
                    // ... LoadReservations()
                    LoadReservations();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void LoadReservations()
        {
            // Pilla el id de la sesión
            int userId = Convert.ToInt32(Session["UserID"]);

            // Crea una lista 'reservations' y guarda los datos que recibe del metodo GetReservationsByUser, que le pasa el id recogido de la sesión
            List<Reservation> reservations = Reservation.GetReservationsByUser(userId);

            // Creamos un html
            StringBuilder html = new StringBuilder();

            // Recorre la lista reservations a partir de la variable r. Los datos leídos de reservations, es decir, del reader
            foreach (var r in reservations)
            {
                // Crea una estructura html, div con una clase y cada dato se pone en forma de <p> y un strong con el titulo de la p.
                // Usa {r.check_in_date} para recoger y mostrar el dato, en este caso del check-in
                html.Append("<div class='reservation-card'>");
                html.Append($"<p><strong>Check-in:</strong> {r.check_in_date}</p>");
                html.Append($"<p><strong>Check-out:</strong> {r.check_out_date}</p>");
                html.Append($"<p><strong>Room type:</strong> {r.type_of_room}</p>");
                html.Append($"<p><strong>Total cost:</strong> {r.total_cost}€</p>");
                // Despues cierra el div
                html.Append("</div>");
            }

            // Esto es para cargar este html en el div con id ReservationsContainer
            ReservationsContainer.InnerHtml = html.ToString();
        }


    }
}