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
            //if (Session["USER_ROLE"].ToString() != "ADMIN")
            //{
            //    Response.Redirect("../Default.aspx");
            //}
        }

        protected void btSearchAccount_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new AccountBAL().GetAccount(this.tbSearchUserName.Text);
                this.tbAccountID.Text = table.Rows[0]["ID"].ToString();
                this.ddlActivated.ClearSelection();
                this.ddlActivated.SelectedValue = table.Rows[0]["GEACTIVEERD"].ToString();
                this.tbEmailAdress.Text = table.Rows[0]["EMAIL"].ToString();
                this.tbUserName.Text = table.Rows[0]["GEBRUIKERSNAAM"].ToString();
                this.tbPassword.Text = table.Rows[0]["PASSWORD"].ToString();
                this.tbFirstName.Text = table.Rows[0]["VOORNAAM"].ToString();
                this.tbLastName.Text = table.Rows[0]["ACHTERNAAM"].ToString();
                this.tbRank.Text = table.Rows[0]["ROL"].ToString();
                this.tbStreet.Text = table.Rows[0]["STRAAT"].ToString();
                this.tbStreetNum.Text = table.Rows[0]["HUISNR"].ToString();
                this.tbZipCode.Text = table.Rows[0]["WOONPLAATS"].ToString();
                this.tbBankrek.Text = table.Rows[0]["BANKNR"].ToString();
            }
            catch(IndexOutOfRangeException)
            {
                Response.Write("<script>alert('Geen gebruiker gevonden');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Er is iets fout gegaan probeer het opnieuw');</script>");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
                if (IsValid)
                {
                    string confirmValue = Request.Form["confirm_value"];
                    if (confirmValue == "Ja")
                    {
                        try
                        {
                            DataTable table = new AccountBAL().GetAccount(tbUserName.Text);
                            new AccountBAL().UpdateAccount(
                                Convert.ToInt32(tbAccountID.Text),
                                this.tbRank.Text,
                                this.tbUserName.Text,
                                this.tbPassword.Text,
                                this.tbEmailAdress.Text,
                                Convert.ToInt32(this.ddlActivated.SelectedItem.Value),
                                this.tbFirstName.Text,
                                this.tbLastName.Text,
                                this.tbStreet.Text,
                                Convert.ToInt32(this.tbStreetNum.Text),
                                tbZipCode.Text,
                                tbBankrek.Text);
                            Response.Redirect("../Account/AccountManagementAdmin.aspx");
                        }
                        catch (FormatException)
                        {
                            Response.Write("<script>alert('Opslaan mislukt, vul de gegevens juist in');</script>");
                        }
                        catch (InvalidOperationException)
                        {
                            Response.Write("<script>alert('Opslaan is mislukt');</script>");
                        }
                    }
                    else
                    {
                    }
                }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {/*
            
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
            }*/
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.tbUserName.Text.Count() > 0 && Session["USER_ID"].ToString() != this.tbUserName.Text)
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Ja")
                {
                    try
                    {
                        new AccountBAL().DeleteAccount(tbUserName.Text);
                        Response.Redirect("../Account/AccountManagementAdmin.aspx");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('Geen user gevonden met het opgegeven username');</script>");
                    }
                }
                else
                {
                }
            }
            else
            {
                Response.Write("<script>alert('Geef een gebruikersnaam op');</script>");
            }
        }
    }
}