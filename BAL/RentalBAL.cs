﻿namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;

    public class RentalBAL
    {
        public DataTable GetAccountByBarcode(string barcode)
        {
            return new RentalDAL().LoadPerson(barcode);
        }
        public int UpdatePresence(int personID, int aanwezig)
        {
            return new RentalDAL().UpdatePresence(personID, aanwezig);

        }
        public DataTable GetPersonByAanwezig(int aanwezig)
        {
            if (aanwezig == 1 || aanwezig == 0)
            {
                return new RentalDAL().LoadAllPersons(aanwezig);
            }
            else
            {
                return null;
            }
        }
        public DataTable GetAccountByName(string name)
        {
            return new RentalDAL().LoadPersonByName(name);
        }
        public DataTable GetAccountByID(int id)
        {
            return new RentalDAL().LoadPersonByID(id);
        }
    }
}
