namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;

    public class EventBAL
    {
        /// <summary>
        /// Constructor for EventBAL
        /// </summary>
        public EventBAL()
        {
        }

        /// <summary>
        /// Gets an event
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns>datatable with all event information</returns>
        public DataTable GetEvent(string eventName)
        {
            return new EventDAL().Load(eventName);
        }

        /// <summary>
        /// Gets all events
        /// </summary>
        /// <returns>dataatable with all event information from all events</returns>
        public DataTable GetAllEvents()
        {
            return new EventDAL().Load();
        }

        /// <summary>
        /// Creates an event
        /// </summary>
        /// <param name="locationID">foreign key of location</param>
        /// <param name="name">name of the event</param>
        /// <param name="start">startdate</param>
        /// <param name="end">enddate</param>
        /// <param name="maxVis">Max visitors</param>
        /// <returns>int if create was succesvol</returns>
        public int CreateEvent(int locationID, string name, string start, string end, int maxVis)
        {
            return new EventDAL().Insert(locationID, name, start, end, maxVis);
        }

        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="naam">event name</param>
        /// <returns>int if delete was succesvol</returns>
        public int DeleteEvent(string naam)
        {
            return new EventDAL().Delete(naam);
        }

        /// <summary>
        /// updates an event
        /// </summary>
        /// <param name="locationID">foreign key of location</param>
        /// <param name="name">name of the event</param>
        /// <param name="start">startdate</param>
        /// <param name="end">enddate</param>
        /// <param name="maxVis">Max visitors</param>
        /// <returns>int if create was succesvol</returns>
        public int SetEvent(string name, string start, string end, int maxVis, int eventid)
        {
            return new EventDAL().Update(name, start, end, maxVis, eventid);
        }
    }
}
