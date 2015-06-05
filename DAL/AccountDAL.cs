﻿// <copyright file="AccountDAL.cs" company="RuudIT">
//      Copyright (c) GHMusic. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
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

        public int Insert(int rankID, string username, string password, int age, string interests, string signature)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Account (AccountID, RangID, Gebruikersnaam, Wachtwoord, Leeftijd, Interesses, Handtekening) 
                VALUES (AccountID_SEQ.nextval, :rankID, :username, :password, :age, :interests, :signature)";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("rankID", rankID));
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    cmd.Parameters.Add(new OracleParameter("password", password));
                    cmd.Parameters.Add(new OracleParameter("age", age));
                    cmd.Parameters.Add(new OracleParameter("interests", interests));
                    cmd.Parameters.Add(new OracleParameter("signature", signature));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
                        return 0;
                    }
                }
            }
        }

        public int Update(int accountID, int rankID, string username, string password, int age, string interests, string signature)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = @"UPDATE Account SET Gebruikersnaam = :username, Wachtwoord = :password, Leeftijd = :age, 
                Interesses = :interests, Handtekening = :signature WHERE AccountID = :accountID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    cmd.Parameters.Add(new OracleParameter("password", password));
                    cmd.Parameters.Add(new OracleParameter("age", age));
                    cmd.Parameters.Add(new OracleParameter("interests", interests));
                    cmd.Parameters.Add(new OracleParameter("signature", signature));
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
                        return 0;
                    }
                }
            }
        }

        public int Delete(int accountID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "DELETE FROM Account WHERE ID = :accountID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
                        return 0;
                    }
                }
            }
        }

        public DataTable Load(int accountID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM Account WHERE ID = :accountID";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    try
                    {
                        a.Fill(t);
                        return t;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
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
                string loadQuery = "SELECT * FROM Account WHERE Gebruikersnaam = :username AND Wachtwoord = :password";
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
                        Console.WriteLine("Error: " + ex.Message.ToString());
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
                        Console.WriteLine("Error: " + ex.Message.ToString());
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
                string checkUser = "SELECT COUNT(*) FROM dual WHERE EXISTS(SELECT AccountID FROM Account WHERE Gebruikersnaam = :username AND Wachtwoord = :password)";
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
                        Console.WriteLine(this.ErrorString(ex));
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
                        Console.WriteLine(this.ErrorString(ex));
                        return 0;
                    }
                }
            }
        }

        public string ErrorString(OracleException ex)
        {
            return "Code: " + ex.ErrorCode + "\n" + "Message: " + ex.Message;
        }
    }
}