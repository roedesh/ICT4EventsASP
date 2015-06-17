namespace ICT4Events.Event
{
    using System;
    using System.Collections.Generic;    
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    public partial class EventManagementAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["USER_ROLE"].ToString() != "ADMIN")
            //{
            //    Response.Redirect("../Default.aspx");
            //}
            DataTable table = new EventBAL().GetAllEvents();
            ddlAllEvents.DataSource = table;
            ddlAllEvents.DataTextField = "NAAM";
            ddlAllEvents.DataValueField = "NAAM";
            ddlAllEvents.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {            
            
        }

        protected void btnSearchEvent_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new EventBAL().GetEvent(this.ddlAllEvents.SelectedItem.Text);
                this.tbEventID.Text = table.Rows[0]["ID"].ToString();
                this.tbEventname.Text = table.Rows[0]["NAAM"].ToString();
                this.tbStartDate.Text = table.Rows[0]["DATUMSTART"].ToString();
                this.tbEndDate.Text = table.Rows[0]["DATUMEINDE"].ToString();
                this.tbMaxVis.Text = table.Rows[0]["MAXBEZOEKERS"].ToString();
                this.tbLocationName.Text = table.Rows[0]["LOCNAAM"].ToString();
                this.tbStreet.Text = table.Rows[0]["STRAAT"].ToString();
                this.tbStreetNr.Text = table.Rows[0]["STRAATNR"].ToString();
                this.tbZipCode.Text = table.Rows[0]["POSTCODE"].ToString();
                this.tbCity.Text = table.Rows[0]["PLAATS"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                Response.Write("<script>alert('Geen event gevonden');</script>");
            }
            catch (ArgumentException)
            {
                Response.Write("<script>alert('Niet alle gegevens konden worden geladen');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Er is iets fout gegaan probeer het opnieuw');</script>");
            }
        }        
    }
}