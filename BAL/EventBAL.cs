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

        public DataTable GetEvent(string eventName)
        {
            return new EventDAL().Load(eventName);
        }

        public DataTable GetAllEvents()
        {
            return new EventDAL().Load();
        }

        public int CreateEvent(int locationID, string name, string start, string end, int maxVis)
        {
            return new EventDAL().Insert(locationID, name, start, end, maxVis);
        }

        public int DeleteEvent(string naam)
        {
            return new EventDAL().Delete(naam);
        }

        public int SetEvent(string name, string start, string end, int maxVis, int eventid)
        {
            return new EventDAL().Update(name, start, end, maxVis, eventid);
        }
    }
}
