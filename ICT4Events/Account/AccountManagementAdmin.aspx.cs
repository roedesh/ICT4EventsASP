

namespace ICT4Events.Account
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;
    using System.Data;
    public partial class AccountManagementAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] == null)
            {
                Response.Redirect("../Account/Registreren.aspx");
            }


        }

        protected void btSearchAccount_Click(object sender, EventArgs e)
        {
            try
            {
                // hier nog de extra velden toevoegen
                DataTable table = new AccountBAL().GetAccount(tbSearchUserName.Text);
                tbEmailAdress.Text = table.Rows[0].Table.Columns["EMAIL"].ToString();
                tbUserName.Text = table.Rows[0].Table.Columns["GEBRUIKERSNAAM"].ToString();
                tbFirstName.Text = table.Rows[0].Table.Columns["VOORNAAM"].ToString();
                tbLastName.Text = table.Rows[0].Table.Columns["ACHTERNAAM"].ToString();
                tbAddress.Text = table.Rows[0].Table.Columns["ADRES"].ToString();
                tbCity.Text = table.Rows[0].Table.Columns["STAD"].ToString();
                tbZipCode.Text = table.Rows[0].Table.Columns["POSTCODE"].ToString();
                tbPhoneNumber.Text = table.Rows[0].Table.Columns["TELEFOONNUMMER"].ToString();
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
                if (IsValid)
                {
                    DataTable table = new AccountBAL().GetAccount(tbUserName.Text);
                    new AccountBAL().UpdateAccount(Convert.ToInt32(table.Rows[0].Table.Columns["ACCOUNTID"]),
                        Convert.ToInt32(tbRank.Text), tbUserName.Text,
                        table.Rows[0].Table.Columns["WACHTWOORD"].ToString(), Convert.ToInt32(tbAge),
                        tbInterests.Text, table.Rows[0].Table.Columns["SIGNATURE"].ToString());
                }
            }
            catch(InvalidOperationException)
            {
                Response.Write("<script>alert('Opslaan is mislukt');</script>");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
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
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    new AccountBAL().DeleteAccount(tbUserName.Text);
                }
            }
            finally
            {

            }
        }
    }
}