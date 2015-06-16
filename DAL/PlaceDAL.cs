using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace DAL
{
    public class PlaceDAL
    {
        public PlaceDAL()
        {

        }

        public int Insert(int placeID, int reservationID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Plek_Reservering VALUES 
                (PLEK_RESERVERING_FCSEQ.nextval, :placeID, :reservationID)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("placeID", placeID));
                    cmd.Parameters.Add(new OracleParameter("reservationID", reservationID));
                    
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
