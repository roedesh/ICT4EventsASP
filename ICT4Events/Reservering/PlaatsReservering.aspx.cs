using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace ICT4Events.Reservering
{
    public partial class PlaatsReservering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calBeginData_SelectionChanged(object sender, EventArgs e)
        {
            cusValBeginDate.Validate();
        }

        protected void cusValBeginDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (calBeginData.SelectedDate <= DateTime.Now)
            {
                args.IsValid = false;
            }
        }

        protected void calEndDate_SelectionChanged(object sender, EventArgs e)
        {
            cusValEndDate.Validate();
        }

        protected void cusValEndDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (calEndDate.SelectedDate <= calBeginData.SelectedDate)
            {
                args.IsValid = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            ReservationBAL rBal = new ReservationBAL();
            PlaceBAL pBal = new PlaceBAL();

            int personID = rBal.CreatePerson(tbFirstName.Text, tbMiddleName.Text, tbLastName.Text,
                tbStreet.Text, tbHouseNr.Text, tbCity.Text, tbBankAccount.Text);
            if (personID > 0)
            {
                Debug.WriteLine("Persoon aangemaakt!");
            }
            int reservationID = rBal.CreateReservation(personID, calBeginData.SelectedDate.Date, calEndDate.SelectedDate.Date);
            if (reservationID > 0)
            {
                Debug.WriteLine("Reservering aangemaakt!");
            }
            int placeReservation = pBal.CreatePlaceReservation(Convert.ToInt32(ddPlace.SelectedItem.Value), reservationID);
            if (placeReservation > 0)
            {
                Debug.WriteLine("Plek_Reservering aangemaakt!");
            }
        }

    }
}