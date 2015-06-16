using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using BAL;

namespace ICT4Events
{
    public partial class Registreren : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    AccountBAL accountbal = new AccountBAL();
                    accountbal.CreateAccount(tbUsername.Text, tbPassword.Text, tbEmail.Text);
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