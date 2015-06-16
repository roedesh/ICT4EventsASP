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
        private int counter;

        /// <summary>
        /// String value to store the hash in.
        /// </summary>
        private string hash;

        /// <summary>
        /// String value to store the email in.
        /// </summary>
        private string email;

        /// <summary>
        /// Integer to return in a method.
        /// </summary>
        private int resultValue;

        /// <summary>
        /// Initializes a new instance of the MailDAL class.
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
                        if (this.counter > 0)
                        {
                            this.hash = null;
                            this.email = null;
                        }
                    }
                }
            }

            return new string[] { this.hash, this.email };
        }

        /// <summary>
        /// Method to activate the account after clicking the activation link.
        /// </summary>
        /// <param name="userID">userID value</param>
        /// <param name="hash">hash value</param>
        /// <returns>Returns an integer value to see if the activation succeeded.</returns>
        public int ActivateAccount(string userID, string hash)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                this.resultValue = 0;
                string selectQuery = "SELECT COUNT(*) FROM DUAL WHERE EXISTS (SELECT * FROM ACCOUNT WHERE ID = :v1 AND ACTIVATIEHASH = :v2)";
                using (OracleCommand cmd = new OracleCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("v1", userID));
                    cmd.Parameters.Add(new OracleParameter("v2", hash));
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            this.counter = Convert.ToInt32(reader[0]);
                        }

                        if (this.counter > 0)
                        {
                            string updateQuery = "UPDATE ACCOUNT SET GEACTIVEERD = 1 WHERE ID = :v1";
                            using (OracleCommand cmd1 = new OracleCommand(updateQuery, conn))
                            {
                                cmd1.Parameters.Add(new OracleParameter("v1", userID));
                                try
                                {
                                    cmd1.ExecuteNonQuery();
                                }
                                catch (OracleException)
                                {
                                    this.counter = 0;
                                }
                                finally
                                {
                                    if (this.counter > 0)
                                    {
                                        this.resultValue = 1;
                                    }
                                }
                            }
                        }
                    }
                    catch (OracleException)
                    {
                        this.counter = 0;
                    }

                    return this.resultValue;
                }
            }
        }
    }
}
