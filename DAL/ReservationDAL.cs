// <copyright file="ReservationDAL.cs" company="RuudIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
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
    /// Class for storing, retrieving and deleting reservations
    /// </summary>
    public class ReservationDAL
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationDAL"/> class
        /// </summary>
        public ReservationDAL()
        {
        }

        /// <summary>
        /// Calls a stored procedure that inserts a person, reservation and place_reservation
        /// </summary>
        /// <param name="firstName">First name of the booker</param>
        /// <param name="insertion">Name insertion of the booker</param>
        /// <param name="lastName">Last name of the booker</param>
        /// <param name="street">Address of the booker</param>
        /// <param name="house_nr">House number of the booker</param>
        /// <param name="city">City of the booker</param>
        /// <param name="iban">IBAN of the booker</param>
        /// <param name="beginDate">Start date of reservation</param>
        /// <param name="endDate">End date of reservation</param>
        /// <param name="placeID">ID of reserved place</param>
        /// <returns>The ID of the new inserted reservation</returns>
        public int Insert(string firstName, string insertion, string lastName, string street, string house_nr, string city, string iban, DateTime beginDate, DateTime endDate, int placeID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "InschrijvingPlaatsen";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_VOORNAAM", OracleDbType.Varchar2).Value = firstName;
                    cmd.Parameters.Add("P_TUSSENVOEGSEL", OracleDbType.Varchar2).Value = insertion;
                    cmd.Parameters.Add("P_ACHTERNAAM", OracleDbType.Varchar2).Value = lastName;
                    cmd.Parameters.Add("P_STRAAT", OracleDbType.Varchar2).Value = street;
                    cmd.Parameters.Add("P_HUISNUMMER", OracleDbType.Varchar2).Value = house_nr;
                    cmd.Parameters.Add("P_WOONPLAATS", OracleDbType.Varchar2).Value = city;
                    cmd.Parameters.Add("P_BANKNR", OracleDbType.Varchar2).Value = iban;
                    cmd.Parameters.Add("P_BEGINDATUM", OracleDbType.Date).Value = beginDate;
                    cmd.Parameters.Add("P_EINDDATUM", OracleDbType.Date).Value = endDate;
                    cmd.Parameters.Add("P_PLEKID", OracleDbType.Int32).Value = placeID;
                    OracleParameter p1 = new OracleParameter("OP_RESERVERINGID", OracleDbType.Int32);
                    p1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p1);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return Convert.ToInt32(p1.Value.ToString());
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
        /// Calls a stored procedure that deletes a reservation and it's children
        /// </summary>
        /// <param name="reservationID">ID of the reservation to be deleted</param>
        /// <returns>0 or 1</returns>
        public int Delete(int reservationID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "verwijderReservering";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter inval = new OracleParameter("reserveringID", OracleDbType.Int32);
                    inval.Direction = ParameterDirection.Input;
                    inval.Value = reservationID;
                    cmd.Parameters.Add(inval);

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

        public DataTable LoadWristbands()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM POLSBANDJE";
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
