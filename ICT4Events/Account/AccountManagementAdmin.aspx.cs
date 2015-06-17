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

    public partial class AccountManagementAdmin : System.Web.UI.Page
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

        protected void btSearchAccount_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new AccountBAL().GetAccount(this.tbSearchUserName.Text);
                this.tbActivated.Text = table.Rows[0]["GEACTIVEERD"].ToString();
                this.tbEmailAdress.Text = table.Rows[0]["EMAIL"].ToString();
                this.tbUserName.Text = table.Rows[0]["GEBRUIKERSNAAM"].ToString();
                this.tbFirstName.Text = table.Rows[0]["VOORNAAM"].ToString();
                this.tbLastName.Text = table.Rows[0]["ACHTERNAAM"].ToString();
                this.tbRank.Text = table.Rows[0]["ROL"].ToString();
                this.tbAddress.Text = table.Rows[0]["STRAATNR"].ToString();
                this.tbCity.Text = table.Rows[0]["WOONPLAATS"].ToString();
                this.tbBankrek.Text = table.Rows[0]["BANKNR"].ToString();
            }
            catch (NullReferenceException)
            {
                Response.Write("<script>alert('Geen gebruiker gevonden');</script>");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IsValid)
                {
                    DataTable table = new AccountBAL().GetAccount(this.tbUserName.Text);
                    new AccountBAL().UpdateAccount(
                        Convert.ToInt32(this.tbAccountID.Text),
                        this.tbRank.Text,
                        this.tbUserName.Text,
                        this.tbPassword.Text);
                }
            }
            catch (InvalidOperationException)
            {
                Response.Write("<script>alert('Opslaan is mislukt');</script>");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Account aangemaakt');</script>");
            this.tbActivated.Text = string.Empty;
            this.tbEmailAdress.Text = string.Empty;
            this.tbUserName.Text = string.Empty;
            this.tbFirstName.Text = string.Empty;
            this.tbLastName.Text = string.Empty;
            this.tbAddress.Text = string.Empty;
            this.tbCity.Text = string.Empty;
            this.tbPhoneNumber.Text = string.Empty;

            /*try
            {
                if (IsValid)
                {
                    //SIGNATURE????? WAT IS DAT
                    new AccountBAL().CreateAccount(Convert.ToInt32(tbRank.Text), tbUserName.Text, tbPassword.Text,
                        Convert.ToInt32(tbAge.Text), tbInterests.Text, "WAT IS DIT??");
                }
            }
            catch (InvalidOperationException)
            {
                Response.Write("<script>alert('Opslaan is mislukt');</script>");
            }*/
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Account verwijderd');</script>");
            this.tbActivated.Text = string.Empty;
            this.tbEmailAdress.Text = string.Empty;
            this.tbUserName.Text = string.Empty;
            this.tbFirstName.Text = string.Empty;
            this.tbLastName.Text = string.Empty;
            this.tbAddress.Text = string.Empty;
            this.tbCity.Text = string.Empty;
            this.tbPhoneNumber.Text = string.Empty;

            /*try
            {
                if (IsValid)
                {
                    new AccountBAL().DeleteAccount(tbUserName.Text);
                }
            }
            finally
            {

            }*/
        }
    }
}