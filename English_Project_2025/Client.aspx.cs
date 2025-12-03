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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                LabelName.Text = Session["Name"].ToString();
                LabelClientName.Text = Session["Name"].ToString();
                LabelClientSurname.Text = Session["Surname"].ToString();
                LabelClientPhone.Text = Session["Mobile"].ToString();
                LabelClientEmail.Text = Session["Email"].ToString();
                LabelClientDOB.Text = Session["DOB"].ToString();
                LabelClientAddress.Text = Session["Address"].ToString();

                if (!IsPostBack)
                {
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
            int userId = Convert.ToInt32(Session["UserID"]);

            List<Reservation> reservations = Reservation.GetReservationsByUser(userId);

            StringBuilder html = new StringBuilder();

            foreach (var r in reservations)
            {
                html.Append("<div class='reservation-card'>");
                html.Append($"<p><strong>Check-in:</strong> {r.check_in_date}</p>");
                html.Append($"<p><strong>Check-out:</strong> {r.check_out_date}</p>");
                html.Append($"<p><strong>Room type:</strong> {r.type_of_room}</p>");
                html.Append($"<p><strong>Total cost:</strong> {r.total_cost}€</p>");
                html.Append("</div>");
            }

            ReservationsContainer.InnerHtml = html.ToString();
        }


    }
}