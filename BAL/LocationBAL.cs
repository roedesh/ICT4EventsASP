namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;

    public class LocationBAL
    {
        public LocationBAL()
        {
        }

        public DataTable GetAllLocations()
        {
            return new LocationDAL().Load();
        }

        public DataTable GetLocation(string name)
        {
            return new LocationDAL().Load(name);
        }


    }
}
