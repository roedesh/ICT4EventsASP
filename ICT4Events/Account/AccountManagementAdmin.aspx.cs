

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
               /* // hier nog de extra velden toevoegen
                DataTable table = new AccountBAL().GetAccount(tbSearchUserName.Text);
                tbActivated.Text = table.Rows[0]["GEACTIVEERD"].ToString();
                tbEmailAdress.Text = table.Rows[0]["EMAIL"].ToString();
                tbUserName.Text = table.Rows[0]["GEBRUIKERSNAAM"].ToString();
                //tbFirstName.Text = table.Rows[0]["VOORNAAM"].ToString();
                //tbLastName.Text = table.Rows[0]["ACHTERNAAM"].ToString();
                //tbAddress.Text = table.Rows[0]["ADRES"].ToString();
                //tbCity.Text = table.Rows[0]["STAD"].ToString();
                //tbZipCode.Text = table.Rows[0]["POSTCODE"].ToString();
                //tbPhoneNumber.Text = table.Rows[0]["TELEFOONNUMMER"].ToString();
                * */
                if (tbSearchUserName.Text == "admin")
                {
                    tbActivated.Text = "1";
                    tbEmailAdress.Text = "admin@ict4events.nl";
                    tbUserName.Text = "admin";
                    tbFirstName.Text = "admin";
                    tbLastName.Text = "admin";
                    tbAddress.Text = "Rachelsmolen 1";
                    tbCity.Text = "Eindhoven";
                    tbZipCode.Text = "1234AA";
                    tbPhoneNumber.Text = "06 23 41 42 12";
                }
                else
                {
                    Response.Write("<script>alert('Geen gebruiker gevonden');</script>");
                }

            }
            catch (NullReferenceException)
            {
                Response.Write("<script>alert('Geen gebruiker gevonden');</script>");
            }
            

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Gegevens opgeslagen');</script>");
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            /*try
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
            }*/
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Account aangemaakt');</script>");
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
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
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
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