// <copyright file="ReservationBAL.cs" company="RuudIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;

    /// <summary>
    /// Class for validating Reservation data and sending it to DAL
    /// </summary>
    public class ReservationBAL
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationBAL"/> class
        /// </summary>
        public ReservationBAL()
        {
        }

        /// <summary>
        /// Calls a stored procedure that inserts a person, reservation and place_reservation
        /// </summary>
        /// <param name="firstName">First name of the booker</param>
        /// <param name="insertion">Name insertion of the booker</param>
        /// <param name="lastName">Last name of the booker</param>
        /// <param name="street">Address of the booker</param>
        /// <param name="house_nr">House number of the booker</param>
        /// <param name="city">City of the booker</param>
        /// <param name="iban">IBAN of the booker</param>
        /// <param name="beginDate">Start date of reservation</param>
        /// <param name="endDate">End date of reservation</param>
        /// <param name="placeID">ID of reserved place</param>
        /// <returns>The ID of the new inserted reservation</returns>
        public int CreateReservation(string firstName, string insertion, string lastName, string street, string house_nr, string city, string iban, DateTime beginDate, DateTime endDate, int placeID)
        {
            return new ReservationDAL().Insert(firstName, insertion, lastName, street, house_nr, city, iban, beginDate, endDate, placeID);
        }

        /// <summary>
        /// Method for deleting a reservation
        /// </summary>
        /// <param name="reservationID">ID of the reservation to be deleted</param>
        /// <returns>0 (failed) or 1 (success)</returns>
        public int DeleteReservation(int reservationID)
        {
            return new ReservationDAL().Delete(reservationID);
        }
    }
}