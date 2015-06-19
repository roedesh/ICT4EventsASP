// <copyright file="RentalBAL.cs" company="TomICT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Thom van Poppel</author>﻿
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
    /// Class for validating Rental data and sending it to DAL
    /// </summary>
    public class RentalBAL
    {
        /// <summary>
        /// Method that loads an account by barcode
        /// </summary>
        /// <param name="barcode">The barcode</param>
        /// <returns>DataTable from account</returns>
        public DataTable GetAccountByBarcode(string barcode)
        {
            return new RentalDAL().LoadPerson(barcode);
        }

        /// <summary>
        /// Update presence of account
        /// </summary>
        /// <param name="personID">ID of the person</param>
        /// <param name="aanwezig">0 or 1 based on presence</param>
        /// <returns>0 or 1</returns>
        public int UpdatePresence(int personID, int aanwezig)
        {
            return new RentalDAL().UpdatePresence(personID, aanwezig);
        }

        /// <summary>
        /// Gets all persons based on presence
        /// </summary>
        /// <param name="aanwezig">0 or 1 based on presence</param>
        /// <returns>DataTable of persons</returns>
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

        /// <summary>
        /// Method that loads an account by name
        /// </summary>
        /// <param name="name">Account name</param>
        /// <returns>DataTable with account</returns>
        public DataTable GetAccountByName(string name)
        {
            return new RentalDAL().LoadPersonByName(name);
        }

        /// <summary>
        /// Method that loads an account by ID
        /// </summary>
        /// <param name="id">Account ID</param>
        /// <returns>DataTable with account</returns>
        public DataTable GetAccountByID(int id)
        {
            return new RentalDAL().LoadPersonByID(id);
        }

        /// <summary>
        /// Get all available items
        /// </summary>
        /// <param name="availlable">0 or 1 based on availability</param>
        /// <returns>0 or 1</returns>
        public DataTable GetAllAvaillableItems(int availlable)
        {
            return new RentalDAL().LoadAllAvaillableItems(availlable);
        }

        /// <summary>
        /// Method for creating a new rental
        /// </summary>
        /// <param name="id">ID of product</param>
        /// <param name="barcode">The barcode</param>
        /// <param name="datumOut">End date</param>
        /// <returns>0 or 1</returns>
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

            succes = new RentalDAL().CreateRental(pbID, id, now, datumOut);
            succes = new RentalDAL().UpdateExemplaar(id, 1);
            return succes;
        }

        /// <summary>
        /// Method that loads all items
        /// </summary>
        /// <returns>DataTable of items</returns>
        public DataTable GetAllItems()
        {
            return new RentalDAL().LoadAllItems();
        }

        /// <summary>
        /// Method for creating a new Item
        /// </summary>
        /// <param name="naam">Name of item</param>
        /// <param name="merk">Item brand</param>
        /// <param name="serie">Item series</param>
        /// <param name="prijs">The price</param>
        /// <param name="aantal">The amount</param>
        /// <returns>0 or 1</returns>
        public int CreateItem(string naam, string merk, string serie, decimal prijs, int aantal)
        {
            int result = 0;
            int id = new RentalDAL().CreateCategory(naam);
            int typenummer = 0;
            int volgnummer = 0;
            if (id != 0)
            {
                typenummer = new RentalDAL().LoadTypenummer();
                id = new RentalDAL().CreateProduct(id, merk, serie, prijs, typenummer);
            }

            if (id != 0)
            {
                for (int i = 0; i < aantal; i++)
                {
                    volgnummer = new RentalDAL().LoadVolgnummer();
                    string barcode = typenummer.ToString() + "." + volgnummer.ToString();
                    result = new RentalDAL().CreateExemplaar(id, barcode, volgnummer);
                }
            }

            return result;
        }
    }
}
