
// <copyright file="MailDAL.cs" company="ICT4Events">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Berry Verschueren</author>
namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess.Client;

    /// <summary>
    /// Class to retrieve data from the database, required to mail.
    /// </summary>
    public class MailDAL
    {
        /// <summary>
        /// Integer value to work with.
        /// </summary>
        int counter;

        /// <summary>
        /// String value to store the hash in.
        /// </summary>
        string hash;

        /// <summary>
        /// String value to store the email in.
        /// </summary>
        string email;

        /// <summary>
        /// Initializes an instance of the MailDAL class.
        /// </summary>
        public MailDAL()
        {
        }

        /// <summary>
        /// Method to select the hash of the specified person
        /// </summary>
        /// <param name="userID">ID value of the requested person.</param>
        /// <returns>Returns a string value containing the hash.</returns>
        public string[] SelectHash(string userID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string selectQuery = "SELECT ACTIVATIEHASH, EMAIL FROM ACCOUNT WHERE ID = :v1";
                using (OracleCommand cmd = new OracleCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("v1", userID));
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            this.hash = reader[0].ToString();
                            this.email = reader[1].ToString();
                        }
                    }
                    catch (OracleException)
                    {
                        this.counter++;
                    }
                    finally
                    {
                        if (counter > 0)
                        {
                            this.hash = null;
                            this.email = null;
                        }
                    }
                }
            }

            return new string[] { this.hash, this.email };
        }

    }
}
