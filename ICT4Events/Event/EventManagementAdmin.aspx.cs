

namespace ICT4Events.Event
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;
    using System.Data;
    public partial class EventManagementAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] == null)
            {
                Response.Redirect("../Account/Registreren.aspx");
            }
            if (Session["USER_ID"].ToString() != "admin")
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Gegevens opgeslagen');</script>");
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Gegevens opgeslagen');</script>");
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btnSearchEvent_Click(object sender, EventArgs e)
        {
            if (tbSearchEvent.Text == "ICT4Events")
            {
                tbAddress.Text = "Rachelsmolen 1";
                tbCity.Text = "Eindhoven";
                tbEventname.Text = "ICT4Events";
                tbZipCode.Text = "1234AA";
            }
            else
            {
                Response.Write("<script>alert('Geen event gevonden');</script>");
            }
        }

        
    }
}