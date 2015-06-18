// <copyright file="ManageReservations.aspx.cs" company="RuudIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
namespace ICT4Events.Reservering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    /// <summary>
    /// WebForm for viewing and deleting reservations
    /// </summary>
    public partial class ManageReservations : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Binds a Delete button to every row that is a valid DataRow
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("btDelete");
                l.Attributes.Add(
                    "onclick", "javascript:return " + "confirm('Weet je zeker dat je dit record wil verwijderen? " + DataBinder.Eval(e.Row.DataItem, "ID") + "')");
            }
        }

        /// <summary>
        /// Event that gets fired whenever a RowCommand is executed
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                ////Get the categoryID of the clicked row
                int resID = Convert.ToInt32(e.CommandArgument);
                ////Delete the record 
                new ReservationBAL().DeleteReservation(resID);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}