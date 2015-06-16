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
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string checkUser = "select count(*) from dual where exists(select username from account where Username = :username)";
                using (OracleCommand cmd = new OracleCommand(checkUser, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("username", tbUsername.Text));
                    try
                    {
                        int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        // If temp is higher than 0, user already exists
                        if (temp > 0)
                        {
                            args.IsValid = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message.ToString());
                    }
                }
            }
        }
    }
}