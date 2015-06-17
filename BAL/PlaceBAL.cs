namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;
    public class PlaceBAL
    {
        public PlaceBAL()
        {

        }

        public int CreatePlaceReservation(int placeID, int reservationID)
        {
            return new PlaceDAL().Insert(placeID, reservationID);
        }

        public int DeletePlaceReservation(int reservationID)
        {
            return new PlaceDAL().DeletePlaceReservation(reservationID);
        }
    }
}
