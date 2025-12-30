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
            LabelMessage.Text = "";
            LabelMessage.ForeColor = System.Drawing.Color.Red;

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
                string BDpath = Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    User user = new User(nameField, surnameField, DOBField, addressField, phoneField,
                                 emailField, passwordField, profileField);

                    user.AddUser(user);

                    NameTextBox.Text = "";
                    SurnameTextBox.Text = "";
                    DOBTextBox.Text = "";
                    PhoneTextBox.Text = "";
                    AddressTextBox.Text = "";
                    ProfileTextBox.Text = "";
                    EmailTextBox.Text = "";
                    PasswordTextBox.Text = "";

                    LabelMessage.Text = "User added successfully!";
                    LabelMessage.ForeColor = System.Drawing.Color.Green;

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
            string searchEmail = searcherTextBox.Text.Trim();
            LabelMessage.Text = "";

            H2SectionTitle.Style["display"] = "none";
            H2ReservationsTitle.Style["display"] = "none";
            PanelUserInfo.Style["display"] = "none";
            PanelReservations.Style["display"] = "none";
            ReservationsContainer.InnerHtml = string.Empty;

            if (string.IsNullOrEmpty(searchEmail))
            {
                LabelMessage.Text = "Please enter an email address to search.";
                return;
            }

            try
            {
                User foundUser = English_Project_2025.User.GetUserByEmail(searchEmail);

                if (foundUser != null)
                {
                    LabelClientName.Text = foundUser.Name;
                    LabelClientSurname.Text = foundUser.Surname;
                    LabelClientDOB.Text = foundUser.DOB;
                    LabelClientPhone.Text = foundUser.Mobile;
                    LabelClientAddress.Text = foundUser.Address;
                    LabelClientEmail.Text = foundUser.Email;

                    int userId = foundUser.Id_user;

                    List<Reservation> userReservations = English_Project_2025.Reservation.GetReservationsByUser(userId);

                    StringBuilder html = new StringBuilder();

                    if (userReservations != null && userReservations.Count > 0)
                    {
                        foreach (var r in userReservations)
                        {
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
                        html.Append("<p>This user has no active reservations.</p>");
                    }

                    ReservationsContainer.InnerHtml = html.ToString();

                    PanelUserInfo.Style["display"] = "grid";
                    H2SectionTitle.Style["display"] = "block";
                    H2ReservationsTitle.Style["display"] = "block";
                    PanelReservations.Style["display"] = "block";

                    LabelMessage.Text = $"User '{foundUser.Name} {foundUser.Surname}' found. Showing {userReservations.Count} reservations.";
                }
                else
                {
                    LabelMessage.Text = $"No user found with email: {searchEmail}";
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "Search failed due to a database error: " + ex.Message;
                H2SectionTitle.Style["display"] = "none";
                H2ReservationsTitle.Style["display"] = "none";
                PanelUserInfo.Style["display"] = "none";
                PanelReservations.Style["display"] = "none";
            }
        }
    }
}