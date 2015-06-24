// <copyright file="AccountManagementAdmin.aspx.cs" company="JonneIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Jonne van Dreven</author>
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

    /// <summary>
    /// WebForm for managing accounts
    /// </summary>
    public partial class AccountManagementAdmin : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ROLE"].ToString() != "ADMIN")
            {
                Response.Redirect("../Default.aspx");
            }

            if (!this.IsPostBack)
            {
                DataTable table = new AccountBAL().GetAllAccounts();
                this.ddlAllAcounts.DataSource = table;
                this.ddlAllAcounts.DataSource = table;
                this.ddlAllAcounts.DataTextField = "GEBRUIKERSNAAM";
                this.ddlAllAcounts.DataValueField = "GEBRUIKERSNAAM";
                this.ddlAllAcounts.DataBind();
            }
        }

        /// <summary>
        /// Click handler for the search button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtSearchAccount_Click(object sender, EventArgs e)
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
                this.ddlRol.ClearSelection();
                this.ddlRol.SelectedValue = table.Rows[0]["ROL"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                Response.Write("<script>alert('Geen gebruiker gevonden');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Er is iets fout gegaan probeer het opnieuw');</script>");
            }
        }

        /// <summary>
        /// Click handler for the save button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
                {
                    string confirmValue = Request.Form["confirm_value"];
                    if (confirmValue == "Ja")
                    {
                        try
                        {
                            new AccountBAL().UpdateAccount(
                                Convert.ToInt32(this.tbAccountID.Text),
                                this.tbUserName.Text,
                                this.tbPassword.Text,
                                this.ddlRol.SelectedValue,
                                this.tbEmailAdress.Text,
                                Convert.ToInt32(this.ddlActivated.SelectedItem.Value));
                            ActiveDirectoryBAL adbal = new ActiveDirectoryBAL();
                            string[] accountData = new AccountBAL().SelectAccount(Convert.ToInt32(this.tbAccountID.Text));
                            string username = accountData[0];
                            //adbal.ChangeUser(username, this.tbUserName.Text, "Username");
                            adbal.ChangeUser(username, this.tbPassword.Text, "Password");
                            //adbal.ChangeUser(username, this.tbEmailAdress.Text, "Email");
                            if (this.ddlRol.SelectedValue.ToString() == "GEBRUIKER")
                            {
                                adbal.RemoveFromGroup(this.tbUserName.Text, "PremiumLeden");
                                adbal.AddToGroup(this.tbUserName.Text, "Leden");
                            }
                            else if (this.ddlRol.SelectedValue.ToString() == "ADMIN")
                            {
                                adbal.RemoveFromGroup(this.tbUserName.Text, "Leden");
                                adbal.AddToGroup(this.tbUserName.Text, "PremiumLeden");
                            }
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

        /// <summary>
        /// Click handler for the create button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Registreren.aspx");
        }

        /// <summary>
        /// Click handler for the delete button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Ja")
            {
                try
                {
                    new AccountBAL().DeleteAccount(this.tbUserName.Text);
                    ActiveDirectoryBAL adbal = new ActiveDirectoryBAL();
                    adbal.DisableAccount(this.tbUserName.Text);
                    Response.Redirect("../Account/AccountManagementAdmin.aspx");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Geen user gevonden met het opgegeven username');</script>");
                }
            }
        }

        /// <summary>
        /// Click handler for the "load user" button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnLoadUser_Click(object sender, EventArgs e)
        {
            DataTable table = new AccountBAL().GetAccount(this.ddlAllAcounts.SelectedItem.Value.ToString());
            this.tbAccountID.Text = table.Rows[0]["ID"].ToString();
            this.ddlActivated.ClearSelection();
            this.ddlActivated.SelectedValue = table.Rows[0]["GEACTIVEERD"].ToString();
            this.tbEmailAdress.Text = table.Rows[0]["EMAIL"].ToString();
            this.tbUserName.Text = table.Rows[0]["GEBRUIKERSNAAM"].ToString();
            this.tbPassword.Text = table.Rows[0]["PASSWORD"].ToString();
            this.ddlRol.ClearSelection();
            this.ddlRol.SelectedValue = table.Rows[0]["ROL"].ToString();
        }
    }
}