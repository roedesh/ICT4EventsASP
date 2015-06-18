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
            if (!IsPostBack)
            {
                DataTable table = new AccountBAL().GetAllAccounts();
                this.ddlAllAcounts.DataSource = table;
                this.ddlAllAcounts.DataSource = table;
                this.ddlAllAcounts.DataTextField = "GEBRUIKERSNAAM";
                this.ddlAllAcounts.DataValueField = "GEBRUIKERSNAAM";
                this.ddlAllAcounts.DataBind();
            }
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
                this.tbRank.Text = table.Rows[0]["ROL"].ToString();
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
                            new AccountBAL().UpdateAccount(
                                Convert.ToInt32(tbAccountID.Text),
                                this.tbUserName.Text,
                                this.tbPassword.Text,
                                this.tbRank.Text,
                                this.tbEmailAdress.Text,
                                Convert.ToInt32(this.ddlActivated.SelectedItem.Value));
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
        {
        }

        protected void btnDelete_Click(object sender, EventArgs e)
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

        protected void btnLoadUser_Click(object sender, EventArgs e)
        {
            DataTable table = new AccountBAL().GetAccount(this.ddlAllAcounts.SelectedItem.Value.ToString());
            this.tbAccountID.Text = table.Rows[0]["ID"].ToString();
            this.ddlActivated.ClearSelection();
            this.ddlActivated.SelectedValue = table.Rows[0]["GEACTIVEERD"].ToString();
            this.tbEmailAdress.Text = table.Rows[0]["EMAIL"].ToString();
            this.tbUserName.Text = table.Rows[0]["GEBRUIKERSNAAM"].ToString();
            this.tbPassword.Text = table.Rows[0]["PASSWORD"].ToString();
            this.tbRank.Text = table.Rows[0]["ROL"].ToString();
        }
    }
}