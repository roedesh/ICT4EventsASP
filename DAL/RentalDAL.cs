﻿namespace DAL
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

    public class RentalDAL
    {
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
        public DataTable LoadAllItems()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string loadQuery = @"SELECT PRODUCT.id,PRODUCT.merk,PRODUCT.serie,PRODUCT.typenummer,PRODUCT.prijs, 
                    count(productexemplaar.product_id) as aantal_exemplaren
                 FROM PRODUCT LEFT JOIN productexemplaar ON (PRODUCT.ID = productexemplaar.product_id)
                    GROUP BY PRODUCT.id,PRODUCT.merk,PRODUCT.serie,PRODUCT.typenummer,PRODUCT.prijs";
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

    }
}
