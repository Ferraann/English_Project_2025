using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace English_Project_2025
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Limpiar la sesion
            Session.Clear();
            // Redirigir a la homepage
            Response.Redirect("Homepage.aspx");
        }
    }
}