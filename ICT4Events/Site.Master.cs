namespace ICT4Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

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
            if (this.Session["USER_ID"] != null)
            {
                this.lbWelkom.Text = "(Welkom " + this.Session["USER_ID"] + ")";
                this.IsLoggedIn = true;

                if (Session["USER_ROLE"].ToString() == "admin")
                {
                    this.IsLoggedInAsAdmin = true;
                }
            }
            else
            {
                this.lbWelkom.Text = string.Empty;
                this.IsLoggedIn = false;
                this.IsLoggedInAsAdmin = false;
            }
        }
    }
}