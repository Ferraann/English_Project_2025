using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace English_Project_2025
{
    public partial class HomepageLoged : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                LabelNameLoged.Text = Session["Name"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}