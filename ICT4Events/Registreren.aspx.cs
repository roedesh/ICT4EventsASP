using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Data;
using BAL;

namespace ICT4Events
{
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
                catch(Exception)
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
                    accountbal.CreateAccount(tbUsername.Text, tbPassword.Text, tbEmail.Text);
                    DataTable t = accountbal.GetAccount(tbUsername.Text);
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
                    accountbal.CheckUsername(tbUsername.Text);
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('Username in use!');</script>");
                }
            }            
        }

        protected void btReset_Click(object sender, EventArgs e)
        {
            tbUsername.Text = String.Empty;
            tbPassword.Text = String.Empty;
            tbConfirmPassword.Text = String.Empty;
            tbEmail.Text = String.Empty;
        }
    }
}