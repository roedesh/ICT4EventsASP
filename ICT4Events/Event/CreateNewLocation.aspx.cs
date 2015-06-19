// <copyright file="CreateNewLocation.aspx.cs" company="JonneIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Jonne van Dreven</author>
namespace ICT4Events
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
    /// WebForm for creating a new location
    /// </summary>
    public partial class CreateNewLocation : System.Web.UI.Page
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
                DataTable table = new LocationBAL().GetAllLocations();
                this.ddlAllLocations.DataSource = table;
                this.ddlAllLocations.DataTextField = "NAAM";
                this.ddlAllLocations.DataValueField = "NAAM";
                this.ddlAllLocations.DataBind();
            }
        }

        /// <summary>
        /// Click handler for the cancel button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/CreateNewEvent.aspx");
        }

        /// <summary>
        /// Click handler for the create button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Ja")
                {
                    if (new LocationBAL().SetLocation(
                        this.tbLocationName.Text, 
                        this.tbStreet.Text,
                        this.tbStreetNr.Text, 
                        this.tbZipCode.Text, 
                        this.tbCity.Text) == 1)
                    {
                        Response.Write("<script>alert('Locatie aangemaakt');</script>");
                        Response.Redirect("../Event/CreateNewEvent.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invoer onjuist');</script>");
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Er is iets fout gegaan, probeer het opnieuw');</script>");
            }
        }

        /// <summary>
        /// Click handler for the load button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            DataTable table = new LocationBAL().GetLocation(ddlAllLocations.SelectedValue.ToString());
            this.tbLocationName.Text = table.Rows[0]["NAAM"].ToString();
            this.tbStreet.Text = table.Rows[0]["STRAAT"].ToString();
            this.tbStreetNr.Text = table.Rows[0]["NR"].ToString();
            this.tbZipCode.Text = table.Rows[0]["POSTCODE"].ToString();
            this.tbCity.Text = table.Rows[0]["PLAATS"].ToString();
        }
    }
}