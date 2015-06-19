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
        /// Method that validates person data and sends it to DAL
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="insertion">String between first and last name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="street">Street name</param>
        /// <param name="house_nr">House number</param>
        /// <param name="city">Name of the city</param>
        /// <param name="iban">A valid IBAN code</param>
        /// <returns>0 or 1</returns>
        public int CreatePerson(string firstName, string insertion, string lastName, string street, string house_nr, string city, string iban)
        {
            return new ReservationDAL().Insert(firstName, insertion, lastName, street, house_nr, city, iban);
        }

        /// <summary>
        /// Method that validates reservation data and sends it to DAL
        /// </summary>
        /// <param name="personID">Person ID</param>
        /// <param name="beginDate">Begin date of reservation</param>
        /// <param name="endDate">End date of reservation</param>
        /// <returns>0 or 1</returns>
        public int CreateReservation(int personID, DateTime beginDate, DateTime endDate)
        {
            return new ReservationDAL().Insert(personID, beginDate, endDate);
        }

        public int CreateReservation(string firstName, string insertion, string lastName, string street, string house_nr, string city, string iban, DateTime beginDate, DateTime endDate, int placeID)
        {
            return new AccountDAL().Insert(firstName, insertion, lastName, street, house_nr, city, iban, beginDate, endDate, placeID);
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