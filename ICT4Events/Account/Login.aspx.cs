
namespace ICT4Events
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;
    using System.Data;

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                Response.Redirect("../Default.aspx");
            }
        }

        
            protected void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {

            if (IsValid)
            {

                string username = ((TextBox)Login1.FindControl("username")).Text;
                string password = ((TextBox)Login1.FindControl("password")).Text;
                int login = new AccountBAL().GetAccountLogin(username, password);
                if (login > 0)
                {
                    DataTable table = new AccountBAL().GetAccount(username, password);
                    Session["USER_ID"] = table.Rows[0]["GEBRUIKERSNAAM"];
                    Session["USER_ROLE"] = table.Rows[0]["ROL"];
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    ((Literal)Login1.FindControl("FailureText")).Text = "Gebruikersnaam en/of wachtwoord is fout";
                    e.Cancel = true;
                }
                
            }
        
        }
    }
}