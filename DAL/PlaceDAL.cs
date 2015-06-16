using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace DAL
{
    class PlaceDAL
    {
        public PlaceDAL()
        {

        }

        public int Insert(int placeID, int reservationID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Persoon VALUES 
                (PERSOON_FCSEQ, :placeID, :reservationID)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("placeID", placeID));
                    cmd.Parameters.Add(new OracleParameter("reservationID", reservationID));
                    
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
    }
}
