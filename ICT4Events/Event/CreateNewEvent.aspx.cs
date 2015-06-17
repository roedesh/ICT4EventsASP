using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace ICT4Events
{
    public partial class CreateNewEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = new LocationBAL().GetAllLocations();
            this.ddlAllLocations.DataSource = table;
            this.ddlAllLocations.DataTextField = "NAAM";
            this.ddlAllLocations.DataValueField = "NAAM";
            this.ddlAllLocations.DataBind();
            this.tbStartDate.Text = DateTime.Now.ToString();
            this.tbEndDate.Text = DateTime.Now.ToString();
        }

        protected void btnCreateLocation_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/CreateNewLocation");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new LocationBAL().GetLocation(ddlAllLocations.SelectedValue.ToString());
                new EventBAL().CreateEvent(Convert.ToInt32(table.Rows[0]["ID"].ToString()),
                    this.tbEventname.Text, Convert.ToDateTime(tbStartDate.Text),
                    Convert.ToDateTime(this.tbEndDate.Text), Convert.ToInt32(this.tbMaxVis.Text));
                Response.Write("<script>alert('Event is aangemaakt');</script>");
            }
            catch(FormatException)
            {
                Response.Write("<script>alert('Velden zijn niet juist ingevuld');</script>");
            }
            catch(Exception)
            {
                Response.Write("<script>alert('Er is iets fout gegaan, probeer het opnieuw');</script>");
            }
        }

        protected void btnLoadLocation_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new LocationBAL().GetLocation(ddlAllLocations.SelectedValue.ToString());
                this.tbLocationName.Text = table.Rows[0]["NAAM"].ToString();
                this.tbStreet.Text = table.Rows[0]["STRAAT"].ToString();
                this.tbStreetNr.Text = table.Rows[0]["STRAATNR"].ToString();
                this.tbZipCode.Text = table.Rows[0]["POSTCODE"].ToString();
                this.tbCity.Text = table.Rows[0]["PLAATS"].ToString();
            }
            catch(Exception)
            {
                Response.Write("<script>alert('Niet alles kon worden geladen');</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/EventManagementAdmin.aspx");
        }

        
    }
}