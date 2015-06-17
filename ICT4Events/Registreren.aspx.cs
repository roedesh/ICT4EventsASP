namespace ICT4Events
{
    using System;
    using System.Configuration;
    using System.Collections.Generic;    
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Oracle.DataAccess.Client;

    using BAL;

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
                    MailBAL mailbal = new MailBAL();
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
                    MailBAL mailbal = new MailBAL();
                    mailbal.SendMail(accountID);
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('Something went wrong during the account creation!');</script>");
                }
            }
        }

        protected void CheckUsername(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                try
                {
                    AccountBAL accountbal = new AccountBAL();
                    accountbal.CheckUsername(this.tbUsername.Text);
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('Username in use!');</script>");
                }
            }            
        }

        protected void btReset_Click(object sender, EventArgs e)
        {
            this.tbUsername.Text = string.Empty;
            this.tbPassword.Text = string.Empty;
            this.tbConfirmPassword.Text = string.Empty;
            this.tbEmail.Text = string.Empty;
        }
    }
}