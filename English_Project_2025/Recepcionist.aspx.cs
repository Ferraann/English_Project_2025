using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
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
            // Limpiamos el mensaje de error anterior
            LabelMessage.Text = "";
            LabelMessage.ForeColor = System.Drawing.Color.Red;

            // 1. Recopilar datos
            string nameField = NameTextBox.Text.Trim();
            string surnameField = SurnameTextBox.Text.Trim();
            string DOBField = DOBTextBox.Text.Trim();
            string phoneField = PhoneTextBox.Text.Trim();
            string addressField = AddressTextBox.Text.Trim();
            string profileField = ProfileTextBox.Text.Trim();
            string emailField = EmailTextBox.Text.Trim();
            string passwordField = PasswordTextBox.Text.Trim();

            // ----------------------------------------------------
            // 2. VALIDACIÓN REGEX
            // ----------------------------------------------------

            // Patrones Regex Estándar
            // Email: Valida un formato de correo electrónico básico
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Mobile: Valida 9 a 15 dígitos opcionales con '+' y espacios (ajusta según el país)
            string phonePattern = @"^(\+?\d{1,3}[\s-]?)?(\d{9,15})$";

            // Patrón para asegurar que el Nombre y Apellido no están vacíos y solo contienen letras
            string textPattern = @"^[A-Za-z\s]+$";

            // Validar Nombre
            if (!Regex.IsMatch(nameField, textPattern) || nameField.Length < 2)
            {
                LabelMessage.Text = "❌ Invalid Name. Use only letters and spaces (min 2 chars).";
                return;
            }

            // Validar Apellido
            if (!Regex.IsMatch(surnameField, textPattern) || surnameField.Length < 2)
            {
                LabelMessage.Text = "❌ Invalid Surname. Use only letters and spaces (min 2 chars).";
                return;
            }

            // Validar Email
            if (!Regex.IsMatch(emailField, emailPattern))
            {
                LabelMessage.Text = "❌ Invalid Email format.";
                return;
            }

            // Validar Teléfono
            // Usamos !IsMatch para verificar si NO cumple el formato
            if (!Regex.IsMatch(phoneField, phonePattern))
            {
                LabelMessage.Text = "❌ Invalid Phone Number format (Use 9 to 15 digits).";
                return;
            }

            // Validar Contraseña (Ejemplo simple: min 6 caracteres)
            if (passwordField.Length < 6)
            {
                LabelMessage.Text = "❌ Password must be at least 6 characters long.";
                return;
            }

            // ----------------------------------------------------
            // 3. CREACIÓN E INSERCIÓN DE USUARIO
            // ----------------------------------------------------

            try
            {
                // El resto del código permanece igual, pero ya sanitizado.
                string BDpath = Server.MapPath("~/bin/users.db");

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + BDpath + ";Version=3;"))
                {
                    conn.Open();

                    User user = new User(nameField, surnameField, DOBField, addressField, phoneField,
                                 emailField, passwordField, profileField);

                    // Asegúrate de que AddUser esté definido como static en la clase User
                    user.AddUser(user);

                    // 4. Limpieza de campos
                    NameTextBox.Text = "";
                    SurnameTextBox.Text = "";
                    DOBTextBox.Text = "";
                    PhoneTextBox.Text = "";
                    AddressTextBox.Text = "";
                    ProfileTextBox.Text = "";
                    EmailTextBox.Text = "";
                    PasswordTextBox.Text = "";

                    // Mensaje de éxito
                    LabelMessage.Text = "✅ User added successfully!";
                    LabelMessage.ForeColor = System.Drawing.Color.Green;

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Este catch ahora solo atrapa errores de BD o lógica de negocios
                LabelMessage.Text = "Adding user failed: " + ex.Message;
                LabelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void searchBtn_Click(object sender, EventArgs e)
        {
            string searchEmail = searcherTextBox.Text.Trim();

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

                    PanelUserInfo.Style["display"] = "grid";

                    SeparatorDiv.Style["display"] = "block"; 

                    H2SectionTitle.Style["display"] = "block";

                    PanelReservations.Style["display"] = "block";



                    LabelMessage.Text = $"User '{foundUser.Name} {foundUser.Surname}' found.";
                }
                else
                {
                    LabelMessage.Text = $"No user found with email: {searchEmail}";
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "Search failed due to a database error: " + ex.Message;
            }
        }
    }
}