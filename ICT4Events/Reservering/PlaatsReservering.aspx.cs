// <copyright file="PlaatsReservering.aspx.cs" company="RuudIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
namespace ICT4Events.Reservering
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    /// <summary>
    /// WebForm for placing a new reservation
    /// </summary>
    public partial class PlaatsReservering : System.Web.UI.Page
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
        /// Event that gets fired whenever a date is selected in calBeginDate
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void calBeginData_SelectionChanged(object sender, EventArgs e)
        {
            this.cusValBeginDate.Validate();
        }

        /// <summary>
        /// Validator for calBeginDate that checks if the selected date if later than today
        /// </summary>
        /// <param name="source">The source of the Event.</param>
        /// <param name="args">The <see cref="System.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValBeginDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.calBeginData.SelectedDate <= DateTime.Now)
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Event that gets fired whenever a date is selected in calEndData
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void calEndDate_SelectionChanged(object sender, EventArgs e)
        {
            this.cusValEndDate.Validate();
        }

        /// <summary>
        /// Validator for calBeginDate that checks if the selected date if later than the begin date
        /// </summary>
        /// <param name="source">The source of the Event.</param>
        /// <param name="args">The <see cref="System.ServerValidateEventArgs"/> instance containing the event data.</param>
        protected void cusValEndDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.calEndDate.SelectedDate <= this.calBeginData.SelectedDate)
            {
                args.IsValid = false;
            }
        }

        /// <summary>
        /// Click event for Button1
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) 
            { 
                return; 
            }

            string[] usernames = (this.tbOtherPersons.Text + "," + Session["USER_ID"].ToString()).Split(',').Select(sValue => sValue.Trim()).ToArray();
            
            foreach (string u in usernames)
            {
                Debug.WriteLine(u);
            }

            ReservationBAL rBal = new ReservationBAL();
            PlaceBAL pBal = new PlaceBAL();
            MailBAL mBal = new MailBAL(false);

            string insertion = this.tbMiddleName.Text;
            if (string.IsNullOrEmpty(insertion))
            {
                insertion = string.Empty;
            }

            int reservationID = rBal.CreateReservation(
                tbFirstName.Text,
                tbMiddleName.Text,
                tbLastName.Text,
                tbStreet.Text,
                tbHouseNr.Text,
                tbCity.Text,
                tbBankAccount.Text,
                calBeginData.SelectedDate.Date,
                calEndDate.SelectedDate.Date,
                Convert.ToInt32(ddPlace.SelectedValue)
            );
            if (reservationID > 0)
            {
                Debug.WriteLine("Reservering aangemaakt: " + reservationID);
            }

            mBal.SendMail(null, usernames, reservationID);
        }
    }
}