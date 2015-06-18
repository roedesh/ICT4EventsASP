namespace ICT4Events
{
    using System;
    using System.Collections.Generic;  
    using System.Configuration;  
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;
    using Oracle.DataAccess.Client;

    public partial class Registreren : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                try
                {
                    string hash = Request.QueryString["RegistrationCode"].ToString();
                    string userID = Request.QueryString["AccountID"].ToString();
                    MailBAL mailbal = new MailBAL(true);
                    bool b = mailbal.ActivateAccount(userID, hash);
                    if (b)
                    {
                        Response.Write("<script language=javascript>alert('Registratie succesvol!');</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('Er is iets mis gegaan bij de activatie van uw account.');</script>");
                }
            }
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    AccountBAL accountbal = new AccountBAL();
                    accountbal.CreateAccount(this.tbUsername.Text, this.tbPassword.Text, this.tbEmail.Text);
                    DataTable t = accountbal.GetAccount(this.tbUsername.Text);
                    string accountID = t.Rows[0]["ID"].ToString();
                    MailBAL mailbal = new MailBAL(true);
                    mailbal.SendMail(accountID);
                    Response.Write("<script language=javascript>alert('An e-mail has been send to you.');</script>");
                }
                catch (Exception x)
                {
                    x.ToString();
                    Response.Write("<script language=javascript>alert('Something went wrong during the account creation!');</script>");
                }
            }
        }

        /// <summary>
        /// Custom validator for checking username
        /// </summary>
        /// <param name="source">Object to validate</param>
        /// <param name="args">Page arguments</param>
        protected void CheckUsername(object source, ServerValidateEventArgs args)
        {
            int exists;
            if (Page.IsValid)
            {
                AccountBAL accountbal = new AccountBAL();
                exists = accountbal.CheckUsername(this.tbUsername.Text);
                if (exists > 0) {
                    args.IsValid = false;
                }
            }            
        }

        /// <summary>
        /// Custom validator for checking email
        /// </summary>
        /// <param name="source">Object to validate</param>
        /// <param name="args">Page arguments</param>
        protected void CheckEmail(object source, ServerValidateEventArgs args)
        {
            int exists;
            if (Page.IsValid)
            {
                AccountBAL accountbal = new AccountBAL();
                exists = accountbal.CheckEmail(this.tbEmail.Text);
                if (exists > 0)
                {
                    args.IsValid = false;
                }
            }
        }

        protected void btReset_Click(object sender, EventArgs e)
        {
            this.tbUsername.Text = string.Empty;
            this.tbPassword.Text = string.Empty;
            this.tbConfirmPassword.Text = string.Empty;
            this.tbEmail.Text = string.Empty;
            MailBAL mb = new MailBAL(true);
        }
    }
}