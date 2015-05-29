using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

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
                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();
                    string insertQuery = "insert into ACCOUNT (Username, Email, Password) values (:username, :email, :password)";
                    using (OracleCommand cmd2 = new OracleCommand(insertQuery, conn))
                    {
                        cmd2.Parameters.Add(new OracleParameter("username", tbUsername.Text));
                        cmd2.Parameters.Add(new OracleParameter("email", tbEmail.Text));
                        cmd2.Parameters.Add(new OracleParameter("password", tbPassword.Text));
                        try
                        {
                            cmd2.ExecuteNonQuery();
                            Response.Write("Registratie is succesvol voltooid!");
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.Message.ToString());
                        }
                    }
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