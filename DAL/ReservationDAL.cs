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

    public class ReservationDAL
    {
        public ReservationDAL()
        {

        }

        /// <summary>
        /// Method for inserting a Person record
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="insertion">A string between the first and last name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="street">Name of street</param>
        /// <param name="house_nr">House number</param>
        /// <param name="city">Name of city</param>
        /// <param name="iban">IBAN number</param>
        /// <returns>ID of the new person</returns>
        public int Insert(string firstName, string insertion, string lastName, string street, string house_nr, string city, string iban)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Persoon VALUES 
                (PERSOON_FCSEQ.nextval, :firstName, :insertion, :lastName, :street, :house_nr, :city, :iban) RETURNING id INTO :returnID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("firstName", firstName));
                    cmd.Parameters.Add(new OracleParameter("insertion", insertion));
                    cmd.Parameters.Add(new OracleParameter("lastName", lastName));
                    cmd.Parameters.Add(new OracleParameter("street", street));
                    cmd.Parameters.Add(new OracleParameter("house_nr", house_nr));
                    cmd.Parameters.Add(new OracleParameter("city", city));
                    cmd.Parameters.Add(new OracleParameter("iban", iban));
                    OracleParameter p1 = new OracleParameter("returnID", OracleDbType.Int32);
                    p1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p1);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return Convert.ToInt32(p1.Value.ToString());
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
        /// Method for inserting a Reservering record
        /// </summary>
        /// <param name="personID">ID of person who created the reservation</param>
        /// <param name="beginDate">The start date of the reservation</param>
        /// <param name="endDate">The end date of the reservation</param>
        /// <returns>ID of the new reservation</returns>
        public int Insert(int personID, DateTime beginDate, DateTime endDate){
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Reservering VALUES 
                (RESERVERING_FCSEQ.nextval, :personID, TO_DATE(:beginDate, 'dd/mm/yyyy'), TO_DATE(:endDate, 'dd/mm/yyyy'), 0) RETURNING id INTO :returnID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("personID", personID));
                    cmd.Parameters.Add(new OracleParameter("beginDate", beginDate.ToString("dd-MM-yyyy")));
                    cmd.Parameters.Add(new OracleParameter("endDate", endDate.ToString("dd-MM-yyyy")));
                    OracleParameter p1 = new OracleParameter("returnID", OracleDbType.Int32);
                    p1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p1);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return Convert.ToInt32(p1.Value.ToString());
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
