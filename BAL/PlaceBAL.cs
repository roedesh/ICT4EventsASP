using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class PlaceBAL
    {
        public PlaceBAL()
        {

        }

        public int CreatePlaceReservation(int placeID, int reservationID)
        {
            return new PlaceDAL().Insert(placeID, reservationID);
        }
    }
}
