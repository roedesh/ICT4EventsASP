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
            if (Session["USER_ROLE"].ToString() != "ADMIN")
            {
                Response.Redirect("../Default.aspx");
            }
            if (!IsPostBack)
            {
                DataTable table = new LocationBAL().GetAllLocations();
                this.ddlAllLocations.DataSource = table;
                this.ddlAllLocations.DataTextField = "NAAM";
                this.ddlAllLocations.DataValueField = "NAAM";
                this.ddlAllLocations.DataBind();
                string dateFormat = "d-MM-yyyy HH:mm:ss";
                this.tbStartDate.Text = DateTime.Now.ToString(dateFormat);
                this.tbEndDate.Text = DateTime.Now.ToString(dateFormat);
            }
        }

        protected void btnCreateLocation_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/CreateNewLocation.aspx");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new LocationBAL().GetLocation(ddlAllLocations.SelectedValue.ToString());
                if (new EventBAL().CreateEvent(Convert.ToInt32(table.Rows[0]["ID"].ToString()),
                    this.tbEventname.Text, tbStartDate.Text,
                    this.tbEndDate.Text, Convert.ToInt32(this.tbMaxVis.Text)) == 1)
                {
                    Response.Write("<script>alert('Event is aangemaakt');</script>");
                    Response.Redirect("../Event/EventManagementAdmin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Event bestaat al');</script>");
                }
                
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
        protected void valDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("28-12-2010 00:00:00");
            DateTime maxDate = DateTime.Parse("28-12-9999 23:59:59");
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }
        protected void valDateCompare_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (IsValid)
            {
                DateTime startDate = Convert.ToDateTime(this.tbStartDate.Text);
                DateTime endDate = Convert.ToDateTime(this.tbEndDate.Text);

                args.IsValid = (endDate > startDate);
            }
        }
        protected void btnLoadLocation_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new LocationBAL().GetLocation(ddlAllLocations.SelectedValue.ToString());
                this.tbLocationName.Text = table.Rows[0]["NAAM"].ToString();
                this.tbStreet.Text = table.Rows[0]["STRAAT"].ToString();
                this.tbStreetNr.Text = table.Rows[0]["NR"].ToString();
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