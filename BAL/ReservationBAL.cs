namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;

    public class ReservationBAL
    {
        public ReservationBAL()
        {

        }

        public int CreatePerson(string firstName, string insertion, string lastName, string street, string house_nr, string city, string iban)
        {
            return new ReservationDAL().Insert(firstName, insertion, lastName, street, house_nr, city, iban);
        }

        public int CreateReservation(int personID, DateTime beginDate, DateTime endDate)
        {
            return new ReservationDAL().Insert(personID, beginDate, endDate);
        }

        public int DeleteReservation(int reservationID)
        {
            return new ReservationDAL().Delete(reservationID);
        }

        public int DeletePerson(int reservationID)
        {
            return new ReservationDAL().DeletePerson(reservationID);
        }


    }
}
