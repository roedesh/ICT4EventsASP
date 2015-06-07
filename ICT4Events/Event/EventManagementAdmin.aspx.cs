

namespace ICT4Events.Event
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;
    using System.Data;
    public partial class EventManagementAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] == null)
            {
                Response.Redirect("../Account/Registreren.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        
    }
}