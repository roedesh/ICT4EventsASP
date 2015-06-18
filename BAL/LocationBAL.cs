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

        public int SetLocation(string naam, string straat, string straatNr, string postcode, string plaats)
        {
            return new LocationDAL().Insert(naam, straat, straatNr, postcode, plaats);
        }

        public int DeleteLocation(string naam)
        {
            return new LocationDAL().Delete(naam);
        }
    }
}
