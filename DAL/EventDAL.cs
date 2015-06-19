// <copyright file="EventDAL.cs" company="JonneIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Jonne van Dreven</author>

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
    /// Class with data layer for places
    /// </summary>
    public class EventDAL
    {
        /// <summary>
        /// Initializes a new instance of the EventDAL class.
        /// </summary>
        public EventDAL()
        {
        }

        /// <summary>
        /// Method to load all event names
        /// </summary>
        /// <returns>Data table with all event names</returns>
        public DataTable Load()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT NAAM FROM EVENT";
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
        /// Method to load a specific event
        /// </summary>
        /// <param name="eventName">event name</param>
        /// <returns>Data table with all information about the event</returns>
        public DataTable Load(string eventName)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT *, LOCATIE.NAAM as LOCNAAM FROM EVENT, LOCATIE WHERE EVENT.NAAM = :eventName AND EVENT.LOCATIE_ID = LOCATIE.ID";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("eventName", eventName));
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
        /// Method for inserting an event
        /// </summary>
        /// <param name="locationID">Foreign key of the location</param>
        /// <param name="name">event name</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="maxVis">max visitors</param>
        /// <returns>integer if insert was successfully done</returns>
        public int Insert(int locationID, string name, string start, string end, int maxVis)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO EVENT VALUES (EVENT_FCSEQ.NEXTVAL, :location_ID, :naam, TO_DATE(:startDag, 'DD-MM-YYYY HH24:MI:SS'), TO_DATE(:endDag, 'DD-MM-YYYY HH24:MI:SS'), :maxVis)";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("location_ID", locationID));
                    cmd.Parameters.Add(new OracleParameter("naam", name));
                    cmd.Parameters.Add(new OracleParameter("startDag", start));
                    cmd.Parameters.Add(new OracleParameter("endDag", end));
                    cmd.Parameters.Add(new OracleParameter("maxVis", maxVis));
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
        /// Method for updating a specific event
        /// </summary>
        /// <param name="name">Event name</param>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <param name="maxVis">Max visitors</param>
        /// <param name="eventid">Event id</param>
        /// <returns>integer if update was successfully done</returns>
        public int Update(string name, string start, string end, int maxVis, int eventid)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = @"UPDATE EVENT SET naam = :naam, datumstart = TO_DATE(:startDag, 'DD-MM-YYYY HH24:MI:SS'), datumeinde = TO_DATE(:endDag, 'DD-MM-YYYY HH24:MI:SS'), maxbezoekers = :maxVis WHERE id = :eventid";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("naam", name));
                    cmd.Parameters.Add(new OracleParameter("startDag", start));
                    cmd.Parameters.Add(new OracleParameter("endDag", end));
                    cmd.Parameters.Add(new OracleParameter("maxVis", maxVis));
                    cmd.Parameters.Add(new OracleParameter("eventid", eventid));
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
        /// Method for deleting an event
        /// </summary>
        /// <param name="naam">event name</param>
        /// <returns>integer if delete was successfully done</returns>
        public int Delete(string naam)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "DELETE FROM Event WHERE Naam = :naam";
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
