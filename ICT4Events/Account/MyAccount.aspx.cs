// <copyright file="MyAccount.aspx.cs" company="JonneIT">
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
    /// WebForm for managing a single user's account
    /// </summary>
    public partial class MyAccount : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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
                this.tbPassword.Text = table.Rows[0]["PASSWORD"].ToString();
            }
        }

        /// <summary>
        /// Click handler for the save button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new AccountBAL().GetAccount(Session["USER_ID"].ToString());
                new AccountBAL().UpdateAccount(
                                Convert.ToInt32(table.Rows[0]["ID"].ToString()),
                                table.Rows[0]["GEBRUIKERSNAAM"].ToString(),
                                table.Rows[0]["PASSWORD"].ToString(),
                                table.Rows[0]["ROL"].ToString());
                ActiveDirectoryBAL adbal = new ActiveDirectoryBAL();
                adbal.ChangeUser(Session["USER_ID"].ToString(), table.Rows[0]["GEBRUIKERSNAAM"].ToString(), "Username");
                adbal.ChangeUser(Session["USER_ID"].ToString(), table.Rows[0]["PASSWORD"].ToString(), "Password");
                adbal.ChangeUser(Session["USER_ID"].ToString(), table.Rows[0]["EMAIL"].ToString(), "Email");
                if (table.Rows[0]["ROL"].ToString() == "GEBRUIKER")
                {
                    adbal.RemoveFromGroup(table.Rows[0]["GEBRUIKERSNAAM"].ToString(), "PremiumLeden");
                    adbal.AddToGroup(table.Rows[0]["GEBRUIKERSNAAM"].ToString(), "Leden");
                }
                else if (table.Rows[0]["ROL"].ToString() == "ADMIN")
                {
                    adbal.RemoveFromGroup(table.Rows[0]["GEBRUIKERSNAAM"].ToString(), "Leden");
                    adbal.AddToGroup(table.Rows[0]["GEBRUIKERSNAAM"].ToString(), "PremiumLeden");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Er is iets fout gegaan tijdens het opslaan, probeer het opnieuw');</script>");
            }
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
                new AccountBAL().DeleteAccount(this.tbUserName.Text);
                ActiveDirectoryBAL adbal = new ActiveDirectoryBAL();
                adbal.DeleteUser(this.tbUserName.Text);
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