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

    public partial class PlaatsReservering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void calBeginData_SelectionChanged(object sender, EventArgs e)
        {
            this.cusValBeginDate.Validate();
        }

        protected void cusValBeginDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.calBeginData.SelectedDate <= DateTime.Now)
            {
                args.IsValid = false;
            }
        }

        protected void calEndDate_SelectionChanged(object sender, EventArgs e)
        {
            this.cusValEndDate.Validate();
        }

        protected void cusValEndDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.calEndDate.SelectedDate <= this.calBeginData.SelectedDate)
            {
                args.IsValid = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) 
            { 
                return; 
            }

            ReservationBAL rBal = new ReservationBAL();
            PlaceBAL pBal = new PlaceBAL();

            string insertion = this.tbMiddleName.Text;
            if (string.IsNullOrEmpty(insertion))
            {
                insertion = string.Empty;
            }

            int personID = rBal.CreatePerson(this.tbFirstName.Text, insertion, this.tbLastName.Text, this.tbStreet.Text, this.tbHouseNr.Text, this.tbCity.Text, this.tbBankAccount.Text);
            if (personID > 0)
            {
                Debug.WriteLine("Persoon aangemaakt!");
            }

            int reservationID = rBal.CreateReservation(personID, this.calBeginData.SelectedDate.Date, this.calEndDate.SelectedDate.Date);
            if (reservationID > 0)
            {
                Debug.WriteLine("Reservering aangemaakt!");
            }

            int placeReservation = pBal.CreatePlaceReservation(Convert.ToInt32(this.ddPlace.SelectedItem.Value), reservationID);
            if (placeReservation > 0)
            {
                Debug.WriteLine("Plek_Reservering aangemaakt!");
            }
        }

        protected void tbAmountPersons_TextChanged(object sender, EventArgs e)
        {

        }
    }
}