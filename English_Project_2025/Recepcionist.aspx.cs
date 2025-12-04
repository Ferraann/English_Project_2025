using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Change_action()
        {

        }
    }
}

/*  pillar los id y hacer qeu si se clica display none a los divs que no queremos y display flex a los 
 *  que si dejar un display flex de añadir reserva como predefinido.
 */