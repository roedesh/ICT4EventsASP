namespace ICT4Events.Account
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

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
                DataTable table = new AccountBAL().GetAccount(Session["USER_ID"].ToString());
                this.tbEmailAdress.Text = table.Rows[0]["EMAIL"].ToString();
                this.tbUserName.Text = table.Rows[0]["GEBRUIKERSNAAM"].ToString();
                this.tbFirstName.Text = table.Rows[0]["VOORNAAM"].ToString();
                this.tbLastName.Text = table.Rows[0]["ACHTERNAAM"].ToString();
                this.tbStreet.Text = table.Rows[0]["STRAAT"].ToString();
                this.tbStreetNum.Text = table.Rows[0]["HUISNR"].ToString();
                this.tbZipCode.Text = table.Rows[0]["WOONPLAATS"].ToString();
                this.tbBankrek.Text = table.Rows[0]["BANKNR"].ToString();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Gegevens zijn opgeslagen');</script>");
            Response.Redirect("../Account/MyAccount.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Ja")
            {
                new AccountBAL().DeleteAccount(tbUserName.Text);
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