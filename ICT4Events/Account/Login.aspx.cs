using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
            protected void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {
                //dit weghalen
                bool isTrue= true;
            if (IsValid)
            {
               //...login(((TextBox)Login1.FindControl("username")).Text,
                    //((TextBox)Login1.FindControl("password")).Text)
                if (isTrue) //hier controleren gebruikersgegevens
                {
                    Session["USER_ID"] = ((TextBox)Login1.FindControl("tbUsername")).Text;
                    Response.Redirect("../default.aspx");
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
}