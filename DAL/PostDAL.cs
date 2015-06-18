// <copyright file="PostDal.cs" company="ICT4EventsASP">
//     Copyright (c) ICT4EventsASP. All rights reserved.
// </copyright>
// <author>Jeroen Pullich</author>
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

    public class PostDAL
    {
        #region Load Queries
        public DataTable LoadFile(string fileID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT bd.ID, bd.ACCOUNT_ID, bd.DATUM, bs.CATEGORIE_ID, bs.BESTANDSLOCATIE, bs.GROOTTE FROM BIJDRAGE bd, BESTAND bs WHERE bd.ID = bs.BIJDRAGE_ID AND bs.BIJDRAGE_ID = :file_id";

                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("file_id", fileID));
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

        public DataTable LoadCategoryFiles(string categoryID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT bd.ID, bd.ACCOUNT_ID, bd.DATUM, bs.BESTANDSLOCATIE FROM BIJDRAGE bd, BESTAND bs WHERE bd.ID = bs.BIJDRAGE_ID AND bs.CATEGORIE_ID = :category_id";

                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("category_id", categoryID));
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

        public DataTable LoadPostMessages(string postID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT bd.ID, bd.ACCOUNT_ID, bd.DATUM, br.TITEL, br.INHOUD FROM BIJDRAGE bd, BERICHT br, BIJDRAGE_BERICHT bb WHERE bd.ID = bb.BERICHT_ID AND br.BIJDRAGE_ID = bb.BERICHT_ID AND bb.BIJDRAGE_ID = :post_id";

                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("post_ID", postID));
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


        public List<int> GetLikeFlagCount(string postID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                List<int> result = new List<int>();

                conn.Open();
                string loadQuery = "SELECT SUM(LIKES) FROM ACCOUNT_BIJDRAGE WHERE BIJDRAGE_ID = :post_id";

                try
                {
                    using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("post_ID", postID));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(Convert.ToInt32(reader.GetValue(0)));
                            }
                        }
                    }

                    loadQuery = "SELECT SUM(ONGEWENST) FROM ACCOUNT_BIJDRAGE WHERE BIJDRAGE_ID = :post_id";

                    using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("post_ID", postID));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(Convert.ToInt32(reader.GetValue(0)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message.ToString());
                    result.Add(0);
                    result.Add(0);
                }

                return result;
            }
        }

        public DataTable LoadRootCategories()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM CATEGORIE WHERE CATEGORIE_ID IS NULL";
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

        public DataTable LoadAllCategories()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM CATEGORIE";
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

        public DataTable LoadChildCategories(string parentID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT * FROM Categorie WHERE categorie_id = :categorie_id";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("category_id", parentID));
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
        #endregion


        #region Insert Queries

        public int GetAccountID(string userName)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                int result = 0;

                conn.Open();
                string query = "SELECT ID FROM ACCOUNT WHERE GEBRUIKERSNAAM = :userName";

                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("userName", userName));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result = Convert.ToInt32(reader.GetValue(0));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message.ToString());
                    result = 0;
                }

                return result;
            }
        }

        public int GetCategoryID(string categoryName)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                int result = 0;

                conn.Open();
                string query = "SELECT BIJDRAGE_ID FROM CATEGORIE WHERE NAAM = :name";

                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("name", categoryName));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result = Convert.ToInt32(reader.GetValue(0));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message.ToString());
                    result = 0;
                }
                return result;
            }
        }

        private int InsertPost(string userName, string type)
        {
            int result = 0;
            string insertQuery = string.Empty;
            try
            {
                string accountID = this.GetAccountID(userName).ToString();

                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();
                    insertQuery = @"INSERT INTO BIJDRAGE (ID, ACCOUNT_ID, DATUM, SOORT) VALUES (BIJDRAGE_FCSEQ.nextval, :accountID, TO_DATE(:uploadDate, 'dd/mm/yyyy'), :kind)";

                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                        cmd.Parameters.Add(new OracleParameter("uploadDate", DateTime.Now.ToString("dd-MM-yyyy")));
                        cmd.Parameters.Add(new OracleParameter("kind", "BESTAND"));

                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OracleException ex)
            {
                Debug.WriteLine(ErrorString(ex));
                result = 0;
            }
            return result;
        }

        public int InsertFile(string userName, string categoryID, string location, string size)
        {
            int result = 0;
            string insertQuery = string.Empty;
            try
            {
                this.InsertPost(userName, "BESTAND");

                string accountID = this.GetAccountID(userName).ToString();

                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();

                    insertQuery = @"INSERT INTO BESTAND (BIJDRAGE_ID, CATEGORIE_ID, BESTANDSLOCATIE, GROOTTE) 
                    VALUES (BIJDRAGE_FCSEQ.currval, :categoryID, :location, :size)";

                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("categoryID", categoryID));
                        cmd.Parameters.Add(new OracleParameter("location", location));
                        cmd.Parameters.Add(new OracleParameter("size", size));

                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OracleException ex)
            {
                Debug.WriteLine(ErrorString(ex));
                result = 0;
            }
            return result;
        }

        public int InsertCategory(string userName, string parentName, string name)
        {
            int result = 0;
            string insertQuery = string.Empty;
            try
            {
                this.InsertPost(userName, "CATEGORIE");

                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        if (parentName == string.Empty)
                        {
                            insertQuery = @"INSERT INTO CATEGORIE (BIJDRAGE_ID, NAAM) VALUES (BIJDRAGE_FCSEQ.currval, :name)";

                            cmd.Parameters.Add(new OracleParameter("name", name));
                        }
                        else
                        {
                            string parentID = this.GetCategoryID(parentName).ToString();

                            insertQuery = @"INSERT INTO CATEGORIE (BIJDRAGE_ID, CATEGORIE_ID, NAAM) VALUES (BIJDRAGE_FCSEQ.currval, :parentID, :name)";

                            cmd.Parameters.Add(new OracleParameter("name", name));
                            cmd.Parameters.Add(new OracleParameter("parentID", parentID));
                        }

                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OracleException ex)
            {
                Debug.WriteLine(ErrorString(ex));
                result = 0;
            }
            return result;
        }

        public int InsertMessage(string userName, string title, string content, string targetID)
        {
            int result = 0;
            string insertQuery = string.Empty;
            try
            {
                this.InsertPost(userName, "BERICHT");

                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();

                    insertQuery = @"INSERT INTO BERICHT (BIJDRAGE_ID, TITEL, INHOUD) 
                    VALUES (BIJDRAGE_FCSEQ.currval, :title, :content)";

                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("title", title));
                        cmd.Parameters.Add(new OracleParameter("content", content));

                        result = cmd.ExecuteNonQuery();
                    }

                    insertQuery = @"INSERT INTO BIJDRAGE_BERICHT (BIJDRAGE_ID, BERICHT_ID) 
                    VALUES (BIJDRAGE_FCSEQ.currval, :targetID)";

                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("targetID", targetID));
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OracleException ex)
            {
                Debug.WriteLine(ErrorString(ex));
                result = 0;
            }
            return result;
        }

        public int InsertLikeFlag(string accountID, string postID, int like, int flag)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();

                string insertQuery = @"INSERT INTO ACCOUNT_BIJDRAGE (ID, ACCOUNT_ID, LIKE, ONGEWENST) 
                VALUES (ACCOUNT_BIJDRAGE_FCSEQ.nextval, :account_ID, :post_ID, :like, :flag)";


                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("account_ID", accountID));
                    cmd.Parameters.Add(new OracleParameter("post_ID", postID));
                    cmd.Parameters.Add(new OracleParameter("like", like));
                    cmd.Parameters.Add(new OracleParameter("flag", flag));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        Debug.WriteLine(ErrorString(ex));
                        return 0;
                    }
                }
            }
        }
        #endregion

        #region Delete Queries
        private int DeletePost(string postID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "DELETE FROM BIJDRAGE WHERE ID = :postID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("postID", postID));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        Debug.WriteLine(ErrorString(ex));
                        return 0;
                    }
                }
            }
        }

        public int DeleteFile(string postID)
        {
            int result = 0;
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "DELETE FROM BESTAND WHERE ID = :postID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("postID", postID));
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        Debug.WriteLine(ErrorString(ex));
                        result = 0;
                    }
                }
            }


            return result;
        }








        #endregion

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