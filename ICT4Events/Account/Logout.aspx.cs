

namespace ICT4Events
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["USER_ID"] != null)
            {
                // logout:
                Session.Remove("USER_ID");
                Session.RemoveAll();
                Response.Write("<script>alert('u bent succesvol uitgelogd');</script>");
                Response.Redirect("../Default.aspx");
            }
            else
            {
                Response.Redirect("../Account/Login.aspx");
            }
        }
    }
}