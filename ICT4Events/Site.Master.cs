using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public bool IsLoggedIn
        {
            get;
            set;
        }
        public bool IsLoggedInAsAdmin
        {
            get;
            set;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                lbWelkom.Text = "(Welkom " + Session["USER_ID"] + ")";
                IsLoggedIn = true;

                if (Session["USER_ROLE"].ToString() == "MEDEWERKER")
                {
                    IsLoggedInAsAdmin = true;
                    
                }
            }
            else
            {
                
                lbWelkom.Text = "";
                IsLoggedIn = false;
                IsLoggedInAsAdmin = false;
            }
        }
    }
}