// <copyright file="EventBAL.cs" company="JonneIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Jonne van Dreven</author>
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
    /// All the logic that involves an event
    /// </summary>
    public class EventBAL
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventBAL"/> class.
        /// </summary>
        public EventBAL()
        {
        }

        /// <summary>
        /// Gets an event
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        /// <returns>data table with all event information</returns>
        public DataTable GetEvent(string eventName)
        {
            return new EventDAL().Load(eventName);
        }

        /// <summary>
        /// Gets all events
        /// </summary>
        /// <returns>DataTable with all event information from all events</returns>
        public DataTable GetAllEvents()
        {
            return new EventDAL().Load();
        }

        /// <summary>
        /// Creates an event
        /// </summary>
        /// <param name="locationID">foreign key of location</param>
        /// <param name="name">name of the event</param>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <param name="maxVis">Max visitors</param>
        /// <returns>integer if create was succesfull</returns>
        public int CreateEvent(int locationID, string name, string start, string end, int maxVis)
        {
            return new EventDAL().Insert(locationID, name, start, end, maxVis);
        }

        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="naam">event name</param>
        /// <returns>int if delete was succesfull</returns>
        public int DeleteEvent(string naam)
        {
            return new EventDAL().Delete(naam);
        }

        /// <summary>
        /// Updates an event
        /// </summary>
        /// <param name="name">Name of the event</param>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <param name="maxVis"Max amount of visitors>Maximun amount of visitors</param>
        /// <param name="eventid">ID of event</param>
        /// <returns>0 or 1</returns>
        public int SetEvent(string name, string start, string end, int maxVis, int eventid)
        {
            return new EventDAL().Update(name, start, end, maxVis, eventid);
        }
    }
}
