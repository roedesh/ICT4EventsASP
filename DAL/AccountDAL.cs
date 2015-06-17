// <copyright file="AccountDAL.cs" company="RuudIT">
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
    /// Class that handles CRUD for the Account table
    /// </summary>
    public class AccountDAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public AccountDAL() 
        { 
        }

        public int Insert(string username, string password, string email)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Account (id, gebruikersnaam, password, email, activatiehash, geactiveerd) 
                VALUES (ACCOUNT_FCSEQ.nextval, :username, :password, :email, :hash, 0)";
                string hash = Guid.NewGuid().ToString();
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    cmd.Parameters.Add(new OracleParameter("password", password));
                    cmd.Parameters.Add(new OracleParameter("email", email));
                    cmd.Parameters.Add(new OracleParameter("hash", hash));
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

        public int Update(int accountID, string username, string password, string role)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = @"UPDATE Account SET Gebruikersnaam = :username, Wachtwoord = :password, ROL = :role WHERE AccountID = :accountID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    cmd.Parameters.Add(new OracleParameter("password", password));;
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    cmd.Parameters.Add(new OracleParameter("role", role));
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

        public int Delete(string username)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "DELETE FROM Account WHERE gebruikersnaam = :gebruikersnaam";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("gebruikersnaam", username));
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

        public DataTable Load(string username)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM ACCOUNT, PERSOON WHERE GEBRUIKERSNAAM = :gebruikersnaam";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("gebruikersnaam", username));
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

        public DataTable Load(string username, string password)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM Account WHERE Gebruikersnaam = :username AND password = :password";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    cmd.Parameters.Add(new OracleParameter("password", password));
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

        public DataTable LoadAll()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM Account";
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

        public int Login(string username, string password)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string checkUser = "SELECT COUNT(*) FROM dual WHERE EXISTS(SELECT ID FROM Account WHERE Gebruikersnaam = :username AND password = :password)";
                using (OracleCommand cmd = new OracleCommand(checkUser, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    cmd.Parameters.Add(new OracleParameter("password", password));
                    try
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    }
                    catch (OracleException ex)
                    {
                        Debug.WriteLine(this.ErrorString(ex));
                        return 0;
                    }
                }
            }
        }

        public int CheckUsername(string username)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string checkUser = "SELECT COUNT(*) FROM dual WHERE EXISTS(SELECT Gebruikersnaam FROM Account WHERE Gebruikersnaam = :username)";
                using (OracleCommand cmd = new OracleCommand(checkUser, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    try
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar().ToString());
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