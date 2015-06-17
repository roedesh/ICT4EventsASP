using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events
{
    public partial class CreateNewLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = new LocationBAL().GetAllLocations();
            this.ddlAllLocations.DataSource = table;
            this.ddlAllLocations.DataTextField = "NAAM";
            this.ddlAllLocations.DataValueField = "NAAM";
            this.ddlAllLocations.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/CreateNewEvent.aspx");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

        }
    }
}