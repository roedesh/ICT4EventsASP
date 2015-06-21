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
                string loadQuery = @"SELECT rp.id, a.gebruikersnaam, rp.aanwezig, r.betaald, p.barcode
                                    FROM Reservering_polsbandje rp
                                    LEFT JOIN account a ON (rp.account_id = a.id)
                                    LEFT JOIN reservering r ON (rp.reservering_id = r.id)
                                    LEFT JOIN polsbandje p ON (rp.polsbandje_id = p.id)
                                    WHERE p.BARCODE =  :barcode";
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
        public int UpdatePresence(int reserveringPolsbandjeID, int aanwezig)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "UPDATE RESERVERING_POLSBANDJE SET AANWEZIG = :aanwezig WHERE ID = :reserveringPolsbandjeID";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("aanwezig", aanwezig));
                    cmd.Parameters.Add(new OracleParameter("personID", reserveringPolsbandjeID));
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
                string loadQuery = @"SELECT rp.id, a.gebruikersnaam, rp.aanwezig, r.betaald, p.barcode
                                    FROM Reservering_polsbandje rp
                                    LEFT JOIN account a ON (rp.account_id = a.id)
                                    LEFT JOIN reservering r ON (rp.reservering_id = r.id)
                                    LEFT JOIN polsbandje p ON (rp.polsbandje_id = p.id)
                                    WHERE rp.AANWEZIG = :aanwezig ";
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
                string loadQuery = @"SELECT rp.id, a.gebruikersnaam, rp.aanwezig, r.betaald, p.barcode
                                    FROM Reservering_polsbandje rp
                                    LEFT JOIN account a ON (rp.account_id = a.id)
                                    LEFT JOIN reservering r ON (rp.reservering_id = r.id)
                                    LEFT JOIN polsbandje p ON (rp.polsbandje_id = p.id)
                                    WHERE a.id = :id ";
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
        public DataTable LoadPersonByName(string name)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = @"SELECT rp.id, a.gebruikersnaam, rp.aanwezig, r.betaald, p.barcode
                                    FROM Reservering_polsbandje rp
                                    LEFT JOIN account a ON (rp.account_id = a.id)
                                    LEFT JOIN reservering r ON (rp.reservering_id = r.id)
                                    LEFT JOIN polsbandje p ON (rp.polsbandje_id = p.id)
                                    WHERE a.gebruikersnaam LIKE '%'||:name||'%'";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("name", name));
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
                string loadQuery = @"SELECT pe.id, pe.barcode, pc.naam as Categorie_Naam, p.merk, p.serie, p.prijs
                                    FROM productexemplaar pe
                                    LEFT JOIN product p ON (pe.product_id = p.id)
                                    LEFT JOIN productcat pc ON (p.productcat_id = pc.id)
                                    WHERE pe.isverhuurd = :availlable";
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
                    cmd.Parameters.Add(new OracleParameter("personID", exemplaarId));
                    cmd.Parameters.Add(new OracleParameter("aanwezig", personId));
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
                string loadQuery = @"SELECT PRODUCTCAT.naam, PRODUCT.id,PRODUCT.merk,PRODUCT.serie,PRODUCT.typenummer,PRODUCT.prijs, PRODUCT.typenummer,
                 count(productexemplaar.product_id) as aantal_exemplaren
                 FROM PRODUCT 
                 LEFT JOIN productexemplaar ON (PRODUCT.ID = productexemplaar.product_id)
                 LEFT JOIN productcat ON (PRODUCT.productcat_id = PRODUCTCAT.id)
                 GROUP BY PRODUCT.id,PRODUCT.merk,PRODUCT.serie,PRODUCT.typenummer,PRODUCT.prijs,PRODUCTCAT.naam, PRODUCT.typenummer
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
        /// <returns>The ID of the created product or 0 when it failed</returns>
        public int CreateProduct(int catID, string merk, string serie, double prijs, int typenummer)
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

        public DataTable LoadExemplaar(string barcode)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = @"SELECT pe.id, pe.barcode, pc.naam as Categorie_Naam, p.merk, p.serie, p.prijs
                                    FROM productexemplaar pe
                                    LEFT JOIN product p ON (pe.product_id = p.id)
                                    LEFT JOIN productcat pc ON (p.productcat_id = pc.id)
                                    WHERE pe.barcode = :barcode";
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

        public DataTable LoadRentalFromPerson(string name)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = @"SELECT pe.id, pc.naam as categorie_naam, p.merk, p.serie, v.datumin, v.datumuit, p.prijs, a.gebruikersnaam
                                    FROM verhuur v
                                    LEFT JOIN productexemplaar pe ON (v.productexemplaar_id = pe.id)
                                    LEFT JOIN product p ON (pe.product_id = p.id)
                                    LEFT JOIN productcat pc ON (p.productcat_id = pc.id)
                                    LEFT JOIN reservering_polsbandje rp ON (v.res_pb_id = rp.id)
                                    LEFT JOIN account a ON (rp.account_id = a.id)
                                    WHERE a.gebruikersnaam LIKE '%'||:name||'%'";
                using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("name", name));
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

        public int UpdateItem(int id, string naam, string merk, string serie, double prijs)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                int succes = 0;
                conn.Open();
                string insertQuery = @"UPDATE productcat SET naam = :naam WHERE id IN (SELECT pc.id
                                    FROM productexemplaar pe
                                    LEFT JOIN product p ON (pe.product_id = p.id)
                                    LEFT JOIN productcat pc ON (p.productcat_id = pc.id)
                                    WHERE p.id = :id)";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("naam", naam));
                    cmd.Parameters.Add(new OracleParameter("id", id));
                    try
                    {
                        succes = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error: " + ex.Message.ToString());
                        return 0;
                    }
                    if(succes == 0)
                    {
                        return 0;
                    }
                }
                insertQuery = @"UPDATE product SET merk = :merk, serie = :serie, prijs = :prijs  WHERE id = :id";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("merk", merk));
                    cmd.Parameters.Add(new OracleParameter("serie", serie));
                    cmd.Parameters.Add(new OracleParameter("prijs", prijs));
                    cmd.Parameters.Add(new OracleParameter("id", id));
                    try
                    {
                        succes = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error: " + ex.Message.ToString());
                        return 0;
                    }
                }
                if (succes == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int LoadItemStatus(int id)
        {
            int result = -1;
            string insertQuery = string.Empty;
            try
            {
                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();

                    string query = @"SELECT isverhuurd FROM productexemplaar WHERE id = :id";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("id", id));
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result = Convert.ToInt32(reader.GetValue(0));
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message.ToString());
                return 0;
            }
        }

        public int DeleteItem(int id)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "DELETE FROM productexemplaar WHERE id = :id";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("id", id));
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

        public List<int> GetAllItemsFromProduct(int id)
        {
            List<int> t = new List<int>();
            try{
                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();
                    string loadQuery = @"SELECT id FROM productexemplaar where product_id = :id";
                    using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                    {
                        OracleDataAdapter a = new OracleDataAdapter(cmd);
                        cmd.Parameters.Add(new OracleParameter("id", id));
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                t.Add(Convert.ToInt32(reader.GetValue(0)));
                            }
                        }
                    }
                }
                return t;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message.ToString());
                return t;
            }
        }

        public List<int> GetAllItemsFromVerhuur(int id)
        {
            List<int> t = new List<int>();
            try
            {
                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                {
                    conn.Open();
                    string loadQuery = @"SELECT id FROM verhuur where productexemplaar_id = :id";
                    using (OracleCommand cmd = new OracleCommand(loadQuery, conn))
                    {
                        OracleDataAdapter a = new OracleDataAdapter(cmd);
                        cmd.Parameters.Add(new OracleParameter("id", id));
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                t.Add(Convert.ToInt32(reader.GetValue(0)));
                            }
                        }
                    }
                }
                return t;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message.ToString());
                return t;
            }
        }

        public int DeleteProduct(int id)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "DELETE FROM product WHERE id = :id";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("id", id));
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
        public int DeleteVerhuur(int id)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string insertQuery = "DELETE FROM verhuur WHERE id = :id";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("id", id));
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
