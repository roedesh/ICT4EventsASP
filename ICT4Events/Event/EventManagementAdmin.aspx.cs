namespace ICT4Events.Event
{
    using System;
    using System.Collections.Generic;    
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    public partial class EventManagementAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["USER_ID"] == null)
            {
                Response.Redirect("../Registreren.aspx");
            }

            if (Session["USER_ID"].ToString() != "admin")
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Gegevens opgeslagen');</script>");
            this.tbAddress.Text = string.Empty;
            this.tbCity.Text = string.Empty;
            this.tbEventname.Text = string.Empty;
            this.tbZipCode.Text = string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {            
            Response.Write("<script>alert('Gegevens opgeslagen');</script>");
            this.tbAddress.Text = string.Empty;
            this.tbCity.Text = string.Empty;
            this.tbEventname.Text = string.Empty;
            this.tbZipCode.Text = string.Empty;
        }

        protected void btnSearchEvent_Click(object sender, EventArgs e)
        {
            if (this.tbSearchEvent.Text == "ICT4Events")
            {
                this.tbAddress.Text = "Rachelsmolen 1";
                this.tbCity.Text = "Eindhoven";
                this.tbEventname.Text = "ICT4Events";
                this.tbZipCode.Text = "1234AA";
            }
            else
            {
                Response.Write("<script>alert('Geen event gevonden');</script>");
            }
        }        
    }
}