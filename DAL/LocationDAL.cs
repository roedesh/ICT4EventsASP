// <copyright file="LocationDAL.cs" company="ICT4Events">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess.Client;

    /// <summary>
    /// All the database methods for locations
    /// </summary>
    public class LocationDAL
    {
        /// <summary>
        /// Constroctor LocationDAL
        /// </summary>
        public LocationDAL()
        {
        }

        /// <summary>
        /// Method for inserting a location
        /// </summary>
        /// <param name="naam">location name</param>
        /// <param name="straat">street name of the location</param>
        /// <param name="straatNr">street number of the location</param>
        /// <param name="postcode">zipcode of the location</param>
        /// <param name="plaats">cityof the location</param>
        /// <returns>int if insert was succesfully done</returns>
        public int Insert(string naam, string straat, string straatNr, string postcode, string plaats)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO LOCATIE VALUES (LOCATIE_FCSEQ.NEXTVAL, :naam, :straat, :nummer, :postcode, :plaats)";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("naam", naam));
                    cmd.Parameters.Add(new OracleParameter("straat", straat));
                    cmd.Parameters.Add(new OracleParameter("nummer", straatNr));
                    cmd.Parameters.Add(new OracleParameter("postcode", postcode));
                    cmd.Parameters.Add(new OracleParameter("plaats", plaats));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        Debug.WriteLine(this.ErrorString(ex));
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Method for loading all locations
        /// </summary>
        /// <returns>Data table with all location names</returns>
        public DataTable Load()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT NAAM FROM LOCATIE";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    try
                    {
                        a.Fill(t);
                        return t;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error: " + ex.Message.ToString());
                        return t;
                    }
                }
            }
        }

        /// <summary>
        /// Method for deleting a location
        /// </summary>
        /// <param name="naam">location name</param>
        /// <returns>int if delete was successfully done</returns>
        public int Delete(string naam)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "DELETE FROM Locatie WHERE Naam = :naam";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("naam", naam));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error: " + ex.Message.ToString());
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Method for loading a location and all its data
        /// </summary>
        /// <param name="name">location name</param>
        /// <returns>Data table with all data of a location</returns>
        public DataTable Load(string name)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM LOCATIE WHERE NAAM = :name";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("name", name));
                    try
                    {
                        a.Fill(t);
                        return t;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error: " + ex.Message.ToString());
                        return t;
                    }
                }
            }
        }

        /// <summary>
        /// Method for returning Oracle exceptions as string
        /// </summary>
        /// <param name="ex">Oracle exception</param>
        /// <returns>Oracle exception as string</returns>
        public string ErrorString(OracleException ex)
        {
            return "Code: " + ex.ErrorCode + "\n" + "Message: " + ex.Message;
        }
    } 
}
