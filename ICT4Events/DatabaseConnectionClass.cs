using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;

namespace ICT4Events
{
    //connectionclass for the database
    public class DatabaseConnectionClass
    {

        #region Main Part of the Class
        //fields
        private OracleConnection con;
        private string connectionString;
        private string data;
        private int counter = 0;
        private string newdata;
        //properties
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        //constructor
        public DatabaseConnectionClass()
        {
            //connectionstring to specify the user data and datasource
            connectionString = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
        }
        // Open the database connection
        public void Connect()
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
        }
        // Close the database connection
        public void Close()
        {
            con.Close();
            con.Dispose();
        }
        #endregion

        #region Update Queries
        #endregion

        #region Delete Queries

        public string deleteStatement(string table, int value)
        {
            data = null;
            try
            {
                string sqlquery = "DELETE FROM " + table + " WHERE ID= :v1";
                var cmd = new OracleCommand(sqlquery, con);
                cmd.Parameters.Add("v1", OracleDbType.Int32).Value = value;                
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                data = ex.ToString();
            }
            return data;
        }
        #endregion

        #region Insert Queries
        public string insertStatement(string table, List<string> values)
        {
            data = null;
            try
            {
                OracleCommand cmd = new OracleCommand(null, con);
                cmd.CommandText = "INSERT INTO " + table + " VALUES (:v1,:v2,:v3,:v4,:v5)";
                cmd.Parameters.Add("v1", OracleDbType.Int32).Value = values[0];
                cmd.Parameters.Add("v2", OracleDbType.Varchar2).Value = values[1];
                cmd.Parameters.Add("v3", OracleDbType.Varchar2).Value = values[2];
                cmd.Parameters.Add("v4", OracleDbType.Int32).Value = values[3];
                cmd.Parameters.Add("v5", OracleDbType.Varchar2).Value = values[4];
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                data = ex.ToString();
            }
            return data;
        }
        public string insertStatement(string table)
        {
            data = null;
            try
            {
                string sqlquery = "SELECT MAX(ID) FROM " + table;
                var cmd = new OracleCommand(sqlquery, con);
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[0] != DBNull.Value)
                        {
                            counter = Convert.ToInt32(reader[0]) + 1;
                        }
                        else { counter = 1; }
                    }
                }
            }
            catch (OracleException ex)
            {
                data = ex.ToString();
            }
            try
            {
                OracleCommand cmd = new OracleCommand(null, con);
                cmd.CommandText = "INSERT INTO " + table + " VALUES (:v1)";
                cmd.Parameters.Add("v1", OracleDbType.Int32).Value = counter;
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                data = ex.ToString();
            }
            return data;
        }
        #endregion

        #region Select Queries
        public string selectStatement(string table, string column, bool max, string value)
        {
            data = null;
            try
            {
                if (!max)
                {
                    string sqlquery = "SELECT " + column + " FROM " + table;
                    var cmd = new OracleCommand(sqlquery, con);
                    cmd.Prepare();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newdata = reader[0] + ";" + reader[1] + ";" + reader[2] + ";" + reader[3] + ";" + reader[4];
                            char[] delemiterChars = {';'};
                            string[] datagroup = newdata.Split(delemiterChars);
                            if (datagroup[1].Contains(value) && value != null)
                            {
                                data = null; break;
                            }
                            data = data + newdata;
                        }
                        data = "database empty";
                    }
                }
                else if (max)
                {
                    string sqlquery = "SELECT MAX(" + column + ") FROM " + table;
                    var cmd = new OracleCommand(sqlquery, con);
                    cmd.Prepare();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader[0] != DBNull.Value)
                            {
                                counter = Convert.ToInt32(reader[0]) +1;
                            }
                            else { counter = 1; }
                        }
                        data = counter.ToString();
                    }
                }
            }
            catch (OracleException ex)
            {
                data = ex.ToString();
            }
            return data;
        }

        public string selectStatement(string table, string column, string attr, string value)
        {
            data = null;
            try
            {
                string sqlquery = "SELECT " + column + " FROM " + table +" WHERE "+ attr +" = :v1";
                var cmd = new OracleCommand(sqlquery, con);
                cmd.Parameters.Add("v1", OracleDbType.Varchar2).Value = value;
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        newdata = reader[0].ToString();
                        data = newdata;
                    }
                }
            }
            catch (OracleException ex)
            {
                data = ex.ToString();
            }
            return data;
        }

        #endregion
    }
}