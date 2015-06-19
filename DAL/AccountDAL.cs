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

        /// <summary>
        /// A method to insert into an account
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <param name="password">password of the account</param>
        /// <param name="email">email of the account</param>
        /// <returns>1 or 0</returns>
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

        /// <summary>
        /// A method to update an account
        /// </summary>
        /// <param name="accountID">ID of the account</param>
        /// <param name="username">username of the account</param>
        /// <param name="password">Password of the account</param>
        /// <param name="role">role of the account</param>
        /// <returns>1 or 0</returns>
        public int Update(int accountID, string username, string password, string role)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = @"UPDATE Account SET Gebruikersnaam = :username, Wachtwoord = :password, ROL = :role WHERE AccountID = :accountID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    cmd.Parameters.Add(new OracleParameter("password", password));
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

        /// <summary>
        /// A method to update an account 
        /// </summary>
        /// <param name="accountID">ID of the account</param>
        /// <param name="password">password of the account</param>
        /// <returns>1 or 0</returns>
        public int Update(int accountID, string password)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = @"UPDATE Account SET Password = :password WHERE ID = :accountID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("password", password));
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
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
        /// A method to update an account
        /// </summary>
        /// <param name="accountID">ID of the account</param>
        /// <param name="username">username of the account</param>
        /// <param name="password">password of the account</param>
        /// <param name="role">role of the account</param>
        /// <param name="email">email of the account</param>
        /// <param name="activated">Whether the account is activated</param>
        /// <returns>1 or 0</returns>
        public int Update(int accountID, string username, string password, string role, string email, int activated)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "UPDATE Account SET Gebruikersnaam = :username, Email = :email, Password = :password, Rol = :role, geactiveerd = :activated WHERE ID = :accountID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    cmd.Parameters.Add(new OracleParameter("email", email));
                    cmd.Parameters.Add(new OracleParameter("password", password)); 
                    cmd.Parameters.Add(new OracleParameter("role", role));
                    cmd.Parameters.Add(new OracleParameter("activated", activated));
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
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
        /// A method to delete an account
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <returns>1 or 0</returns>
        public int Delete(string username)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "UPDATE Account SET geactiveerd = 0 WHERE gebruikersnaam = :gebruikersnaam";
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

        /// <summary>
        /// A method to load an account
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <returns>A account</returns>
        public DataTable Load(string username)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM ACCOUNT WHERE GEBRUIKERSNAAM = :gebruikersnaam";
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

        /// <summary>
        /// A method to load an account
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <param name="password">password of the account</param>
        /// <returns>A Account</returns>
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

        /// <summary>
        /// A method to load all accounts
        /// </summary>
        /// <returns>All accounts</returns>
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

        /// <summary>
        /// A method to login an account
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <param name="password">password of the account</param>
        /// <returns>1 or 0</returns>
        public int Login(string username, string password)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string checkUser = "SELECT COUNT(*) FROM dual WHERE EXISTS(SELECT ID FROM Account WHERE Gebruikersnaam = :username AND password = :password AND geactiveerd = 1)";
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

        /// <summary>
        /// A method to check a username of an account
        /// </summary>
        /// <param name="username">of the account</param>
        /// <returns>1 or 0</returns>
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
        /// A method to check the email of an account
        /// </summary>
        /// <param name="email">email of the account</param>
        /// <returns>1 or 0</returns>
        public int CheckEmail(string email)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string checkUser = "SELECT COUNT(*) FROM dual WHERE EXISTS(SELECT Email FROM Account WHERE UPPER(Email) = UPPER(:email))";
                using (OracleCommand cmd = new OracleCommand(checkUser, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("email", email));
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