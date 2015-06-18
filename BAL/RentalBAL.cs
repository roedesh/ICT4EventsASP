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
        public DataTable GetAllAvaillableItems(int availlable)
        {
            return new RentalDAL().LoadAllAvaillableItems(availlable);
        }
        public int CreateRental(int id, string barcode, string datumOut)
        {
            string dateFormat = "d-MM-yyyy HH:mm:ss";
            string now = DateTime.Now.ToString(dateFormat);
            int succes = 0;
            DataTable dt = new RentalDAL().LoadPerson(barcode);
            long pbID = 0;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    pbID = row.Field<long>(0);
                }
                
            }
            catch
            {
            }
            succes =  new RentalDAL().CreateRental(pbID,id,now,datumOut);
            succes = new RentalDAL().UpdateExemplaar(id,1);
            return succes;

        }
        public DataTable GetAllItems()
        {
            return new RentalDAL().LoadAllItems();
        }
    }
}
