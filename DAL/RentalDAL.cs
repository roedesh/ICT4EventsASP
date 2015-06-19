// <copyright file="RentalDAL.cs" company="TomICT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Thom van Poppel</author>﻿﻿
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
    /// Class for loading, inserting and updating Rental data
    /// </summary>
    public class RentalDAL
    {
        /// <summary>
        /// Method that loads an account by barcode
        /// </summary>
        /// <param name="barcode">The barcode</param>
        /// <returns>DataTable from account</returns>
        public DataTable LoadPerson(string barcode)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT rp.ID, p.VOORNAAM ,p.TUSSENVOEGSEL ,p.ACHTERNAAM ,p.STRAAT ,p.HUISNR ,p.WOONPLAATS ,p.BANKNR,rp.AANWEZIG, r.BETAALD FROM POLSBANDJE pb, RESERVERING_POLSBANDJE rp, RESERVERING r, PERSOON p WHERE p.ID = r.PERSOON_ID AND r.ID = rp.RESERVERING_ID AND pb.ID = POLSBANDJE_ID AND pb.BARCODE =  :barcode ";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("barcode", barcode));
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
        /// Update presence of account
        /// </summary>
        /// <param name="personID">ID of the person</param>
        /// <param name="aanwezig">0 or 1 based on presence</param>
        /// <returns>0 or 1</returns>
        public int UpdatePresence(int personID, int aanwezig)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "UPDATE RESERVERING_POLSBANDJE SET AANWEZIG = :aanwezig WHERE ID = :personID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("aanwezig", aanwezig));
                    cmd.Parameters.Add(new OracleParameter("personID", personID));
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
        /// Gets all persons based on presence
        /// </summary>
        /// <param name="aanwezig">0 or 1 based on presence</param>
        /// <returns>DataTable of persons</returns>
        public DataTable LoadAllPersons(int aanwezig)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT rp.ID, p.VOORNAAM ,p.TUSSENVOEGSEL ,p.ACHTERNAAM ,p.STRAAT ,p.HUISNR ,p.WOONPLAATS ,p.BANKNR,rp.AANWEZIG, r.BETAALD FROM PERSOON p, RESERVERING r, RESERVERING_POLSBANDJE rp WHERE p.ID = r.PERSOON_ID AND rp.RESERVERING_ID = r.ID AND rp.AANWEZIG = :aanwezig ";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("aanwezig", aanwezig));
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

        /// <summary>
        /// Method that loads an person by ID
        /// </summary>
        /// <param name="id">Account ID</param>
        /// <returns>DataTable with account</returns>
        public DataTable LoadPersonByID(int id)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT rp.ID, p.VOORNAAM ,p.TUSSENVOEGSEL ,p.ACHTERNAAM ,p.STRAAT ,p.HUISNR ,p.WOONPLAATS ,p.BANKNR,rp.AANWEZIG, r.BETAALD FROM POLSBANDJE pb, RESERVERING_POLSBANDJE rp, RESERVERING r, PERSOON p WHERE p.ID = r.PERSOON_ID AND r.ID = rp.RESERVERING_ID AND pb.ID = POLSBANDJE_ID AND p.id = :id ";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("id", id));
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
        /// Method that loads an account by name
        /// </summary>
        /// <param name="naam">Account name</param>
        /// <returns>DataTable with account</returns>
        public DataTable LoadPersonByName(string naam)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = "SELECT RP.ID, P.VOORNAAM, P.TUSSENVOEGSEL, P.ACHTERNAAM, P.STRAAT, P.HUISNR, P.WOONPLAATS, P.BANKNR, RP.AANWEZIG, R.BETAALD, R.ID, RP.ID FROM PERSOON P INNER JOIN RESERVERING R ON P.ID = R.PERSOON_ID INNER JOIN RESERVERING_POLSBANDJE RP ON R.ID = RP.RESERVERING_ID INNER JOIN POLSBANDJE PB ON PB.ID = RP.POLSBANDJE_ID WHERE P.VOORNAAM LIKE '%'||:naam||'%' OR P.ACHTERNAAM LIKE '%'||:naam||'%'";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("naam", naam));
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
        /// Get all available items
        /// </summary>
        /// <param name="availlable">0 or 1 based on availability</param>
        /// <returns>0 or 1</returns>
        public DataTable LoadAllAvaillableItems(int availlable)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = @"SELECT pe.id,p.merk, p.serie, p.typenummer, p.prijs, pc.naam  
                FROM productexemplaar pe, product p, productcat pc
                WHERE pe.product_id = p.id 
                AND p.productcat_id = pc.id
                AND pe.ISVERHUURD = :availlable
                ORDER BY pe.id";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("availlable", availlable));
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

        /// <summary>
        /// Method for creating a new rental
        /// </summary>
        /// <param name="personId">ID of person</param>
        /// <param name="exemplaarId">ID of product</param>
        /// <param name="datumIn">Begin date</param>
        /// <param name="datumOut">End date</param>
        /// <returns>0 or 1</returns>
        public int CreateRental(long personId, int exemplaarId, string datumIn, string datumOut)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO VERHUUR VALUES(VERHUUR_FCSEQ.nextval,:exemplaarId,:personId,TO_DATE(:datumIn,'DD-MM-YYYY HH24:MI:SS'),TO_DATE(:datumOut,'DD-MM-YYYY HH24:MI:SS'),0,0)";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("aanwezig", personId));
                    cmd.Parameters.Add(new OracleParameter("personID", exemplaarId));
                    cmd.Parameters.Add(new OracleParameter("datumIn", datumIn));
                    cmd.Parameters.Add(new OracleParameter("datumOut", datumOut));
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
        /// Method for updating an object
        /// </summary>
        /// <param name="exemplaarID">Object ID</param>
        /// <param name="isVerhuurd">Is rented or not</param>
        /// <returns>0 or 1</returns>
        public int UpdateExemplaar(int exemplaarID, int isVerhuurd)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "UPDATE PRODUCTEXEMPLAAR SET ISVERHUURD = :isVerhuurd WHERE ID = :exemplaarID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("aanwezig", isVerhuurd));
                    cmd.Parameters.Add(new OracleParameter("personID", exemplaarID));
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
        /// Loads all items
        /// </summary>
        /// <returns>DataTable of items</returns>
        public DataTable LoadAllItems()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = @"SELECT PRODUCTCAT.naam, PRODUCT.id,PRODUCT.merk,PRODUCT.serie,PRODUCT.typenummer,PRODUCT.prijs, 
                 count(productexemplaar.product_id) as aantal_exemplaren
                 FROM PRODUCT 
                 LEFT JOIN productexemplaar ON (PRODUCT.ID = productexemplaar.product_id)
                 LEFT JOIN productcat ON (PRODUCT.productcat_id = PRODUCTCAT.id)
                 GROUP BY PRODUCT.id,PRODUCT.merk,PRODUCT.serie,PRODUCT.typenummer,PRODUCT.prijs,PRODUCTCAT.naam
                 ORDER BY PRODUCT.merk";
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

        /// <summary>
        /// Method for creating a category
        /// </summary>
        /// <param name="naam">Name of category</param>
        /// <returns>0 or 1</returns>
        public int CreateCategory(string naam)
        {
            int result = 0;
            int id2 = 0;
            string insertQuery = string.Empty;
            try
            {
                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT PRODUCTCAT_FCSEQ.NEXTVAL FROM DUAL";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id2 = Convert.ToInt32(reader.GetValue(0));
                            }
                        }
                    }

                    insertQuery = "INSERT INTO PRODUCTCAT(id,naam) VALUES(:id,:naam)";
                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("id", id2));
                        cmd.Parameters.Add(new OracleParameter("naam", naam));
                        result = cmd.ExecuteNonQuery();
                    }
                }

                if (result != 0)
                {
                    result = id2;
                }

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message.ToString());
                return 0;
            }
        }

        /// <summary>
        /// Method for creating a product
        /// </summary>
        /// <param name="catID">Category ID</param>
        /// <param name="merk">Product brand</param>
        /// <param name="serie">Product series</param>
        /// <param name="prijs">The price</param>
        /// <param name="typenummer">Type number</param>
        /// <returns>0 or 1</returns>
        public int CreateProduct(int catID, string merk, string serie, decimal prijs, int typenummer)
        {
            int result = 0;
            int id2 = 0;
            string insertQuery = string.Empty;
            try
            {
                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT PRODUCT_FCSEQ.NEXTVAL FROM DUAL";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id2 = Convert.ToInt32(reader.GetValue(0));
                            }
                        }
                    }

                    insertQuery = "INSERT INTO PRODUCT VALUES(:id2,:catID,:merk,:serie,:typenummer,:prijs)";
                    using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("id2", id2));
                        cmd.Parameters.Add(new OracleParameter("catID", catID));
                        cmd.Parameters.Add(new OracleParameter("merk", merk));
                        cmd.Parameters.Add(new OracleParameter("serie", serie));
                        cmd.Parameters.Add(new OracleParameter("typenummer", typenummer));
                        cmd.Parameters.Add(new OracleParameter("prijs", prijs));
                        result = cmd.ExecuteNonQuery();
                    }
                }

                if (result != 0)
                {
                    result = id2;
                }

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message.ToString());
                return 0;
            }
        }

        /// <summary>
        /// Method for creating an object
        /// </summary>
        /// <param name="id">Category ID</param>
        /// <param name="barcode">The barcode</param>
        /// <param name="volgnummer">Tracking number</param>
        /// <returns>0 or 1</returns>
        public int CreateExemplaar(int id, string barcode, int volgnummer)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO PRODUCTEXEMPLAAR VALUES(PRODUCTEXEMPLAAR_FCSEQ.nextval,:id,:volgnummer,:barcode,0)";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("id", id));
                    cmd.Parameters.Add(new OracleParameter("volgnummer", volgnummer));
                    cmd.Parameters.Add(new OracleParameter("barcode", barcode));
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
        /// Load type number
        /// </summary>
        /// <returns>The type number</returns>
        public int LoadTypenummer()
        {
                int id2 = 0;
                string insertQuery = string.Empty;
                try
                {
                    using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                    {
                        conn.Open();

                        string query = @"SELECT TYPENUMMER_FCSEQ.NEXTVAL FROM DUAL";

                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            using (OracleDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    id2 = Convert.ToInt32(reader.GetValue(0));
                                }
                            }
                        }
                    }

                    return id2;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message.ToString());
                    return 0;
                }
        }

        /// <summary>
        /// Load tracking number
        /// </summary>
        /// <returns>Tracking number</returns>
        public int LoadVolgnummer()
        {
            int id2 = 0;
            string insertQuery = string.Empty;
            try
            {
                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT VOLGNUMMER_FCSEQ.NEXTVAL FROM DUAL";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id2 = Convert.ToInt32(reader.GetValue(0));
                            }
                        }
                    }
                }

                return id2;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message.ToString());
                return 0;
            }
        }
        public int UpdateItem(int personID, int aanwezig)
        {
            //under construction
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "UPDATE RESERVERING_POLSBANDJE SET AANWEZIG = :aanwezig WHERE ID = :personID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("aanwezig", aanwezig));
                    cmd.Parameters.Add(new OracleParameter("personID", personID));
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
    }
}
