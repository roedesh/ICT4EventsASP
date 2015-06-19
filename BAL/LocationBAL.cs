// <copyright file="PostBAL.cs" company="ICT4EventsASP">
//     Copyright (c) ICT4EventsASP. All rights reserved.
// </copyright>

namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;

    /// <summary>
    /// All the logic for the locations
    /// </summary>
    public class LocationBAL
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationBAL"/> class.
        /// </summary>
        public LocationBAL()
        {
        }

        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <returns>data table with all information about the locations</returns>
        public DataTable GetAllLocations()
        {
            return new LocationDAL().Load();
        }

        /// <summary>
        /// Gets a location
        /// </summary>
        /// <param name="name">Location name</param>
        /// <returns>Data table with all information about the location</returns>
        public DataTable GetLocation(string name)
        {
            return new LocationDAL().Load(name);
        }

        /// <summary>
        /// Inserts a location
        /// </summary>
        /// <param name="naam">Location name</param>
        /// <param name="straat">street name</param>
        /// <param name="straatNr">street number</param>
        /// <param name="postcode">zip code of the location</param>
        /// <param name="plaats">city of the location</param>
        /// <returns>integer if insert was successfully done</returns>
        public int SetLocation(string naam, string straat, string straatNr, string postcode, string plaats)
        {
            return new LocationDAL().Insert(naam, straat, straatNr, postcode, plaats);
        }

        /// <summary>
        /// Deletes a location
        /// </summary>
        /// <param name="naam">Location name</param>
        /// <returns>Integer if delete was successfully done</returns>
        public int DeleteLocation(string naam)
        {
            return new LocationDAL().Delete(naam);
        }
    }
}
