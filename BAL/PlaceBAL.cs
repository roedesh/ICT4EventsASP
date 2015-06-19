﻿// <copyright file="PostBAL.cs" company="ICT4EventsASP">
//     Copyright (c) ICT4EventsASP. All rights reserved.
// </copyright>
namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;
    /// <summary>
    /// Initializes a new instance of the <see cref="PlaceBAL"/> class.
    /// </summary>
    public class PlaceBAL
    {
        /// <summary>
        /// The constructor of PlaceBAL
        /// </summary>
        public PlaceBAL()
        {
        }

        /// <summary>
        /// A method to create a place
        /// </summary>
        /// <param name="placeID">ID of the place</param>
        /// <param name="reservationID">ID of the reservation</param>
        /// <returns>1 or 0</returns>
        public int CreatePlaceReservation(int placeID, int reservationID)
        {
            return new PlaceDAL().Insert(placeID, reservationID);
        }

        /// <summary>
        /// A method to delete a reservation
        /// </summary>
        /// <param name="reservationID">ID of the reservation</param>
        /// <returns>1 or 0</returns>
        public int DeletePlaceReservation(int reservationID)
        {
            return new PlaceDAL().DeletePlaceReservation(reservationID);
        }
    }
}
