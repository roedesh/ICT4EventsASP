// <copyright file="EventManagementAdmin.aspx.cs" company="JonneIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Jonne van Dreven</author>
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

    /// <summary>
    /// WebForm for managing events
    /// </summary>
    public partial class EventManagementAdmin : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ROLE"].ToString() != "ADMIN")
            {
                Response.Redirect("../Default.aspx");
            }

            if (!this.IsPostBack)
            {
                DataTable table = new EventBAL().GetAllEvents();
                this.ddlAllEvents.DataSource = table;
                this.ddlAllEvents.DataTextField = "NAAM";
                this.ddlAllEvents.DataValueField = "NAAM";
                this.ddlAllEvents.DataBind();
            }
        }

        /// <summary>
        /// Click handler for the create button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/CreateNewEvent.aspx");
        }

        /// <summary>
        /// Click handler for the save button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IsValid)
                {
                    string confirmValue = Request.Form["confirm_value"];
                    if (confirmValue == "Ja")
                    {
                        if (new EventBAL().SetEvent(
                            this.tbEventname.Text, 
                            this.tbStartDate.Text,
                            this.tbEndDate.Text, 
                            Convert.ToInt32(this.tbMaxVis.Text),
                            Convert.ToInt32(this.tbEventID.Text)) == 1)
                        {
                            Response.Write("<script>alert('Event is bijgewerkt');</script>");
                            Response.Redirect("../Event/EventManagementAdmin.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Er is iets fout gegaan probeer het opnieuw');</script>");
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Opslaan mislukt. Vul de gegevens juist in');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Event kon niet worden bijgewerkt, probeer het opnieuw.');</script>");
            }
        }

        /// <summary>
        /// Validator for valDateRange
        /// </summary>
        /// <param name="source">Object to validate</param>
        /// <param name="args">Validation arguments</param>
        protected void ValDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("28-12-2010 00:00:00");
            DateTime maxDate = DateTime.Parse("28-12-9999 23:59:59");
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }

        /// <summary>
        /// Validator for valDateCompare
        /// </summary>
        /// <param name="source">Object to validate</param>
        /// <param name="args">Validation arguments</param>
        protected void ValDateCompare_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.IsValid)
            {
                DateTime startDate = Convert.ToDateTime(this.tbStartDate.Text);
                DateTime endDate = Convert.ToDateTime(this.tbEndDate.Text);
                args.IsValid = (endDate > startDate);
            }
        }

        /// <summary>
        /// Click handler for the search button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSearchEvent_Click(object sender, EventArgs e)
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
                this.tbStreetNr.Text = table.Rows[0]["NR"].ToString();
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

        /// <summary>
        /// Click handler for the delete button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                if (new EventBAL().DeleteEvent(this.tbEventname.Text) == 1)
                {
                    Response.Write("<script>alert('Event verwijderd');</script>");
                    Response.Redirect("../Event/EventManagementAdmin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Event niet gevonden');</script>");
                }
            }
        }
    }
}