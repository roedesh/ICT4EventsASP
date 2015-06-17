namespace ICT4Events.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["USER_ID"] == null)
            {
                Response.Redirect("../Registreren.aspx");
            }
            else
            {
                this.tbEmailAdress.Text = "email@ict4events.nl";
                this.tbUserName.Text = Session["USER_ID"].ToString();
                this.tbFirstName.Text = "voornaam";
                this.tbLastName.Text = "achternaam";
                this.tbAddress.Text = "Rachelsmolen 1";
                this.tbCity.Text = "Eindhoven";
                this.tbZipCode.Text = "1234AA";
                this.tbPhoneNumber.Text = "06 12 34 56 78";                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Gegevens zijn opgeslagen');</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Ja")
            {
                Response.Write("<script>alert('Uw account is verwijderd');</script>");
                Session.Remove("USER_ID");
                Session.RemoveAll();
                Response.Redirect("../Default.aspx");
            }
            else
            {
            }
        }
    }
}