// <copyright file="MailDAL.cs" company="ICT4Events">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Berry Verschueren</author>
namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;
    using Oracle.DataAccess.Client;

    /// <summary>
    /// Class to retrieve data from the database, required to mail.
    /// </summary>
    public class MailDAL
    {
        /// <summary>
        /// List to work with strings.
        /// </summary>
        private List<string> Accounts;

        /// <summary>
        /// List to work with strings.
        /// </summary>
        private List<int> IDS;

        /// <summary>
        /// Integer value to work with.
        /// </summary>
        private int counter;

        /// <summary>
        /// String value to store the hash in.
        /// </summary>
        private string hash;

        /// <summary>
        /// String value to store the email in.
        /// </summary>
        private string email;

        /// <summary>
        /// Integer to return in a method.
        /// </summary>
        private int resultValue;

        /// <summary>
        /// Initializes a new instance of the MailDAL class.
        /// </summary>
        public MailDAL()
        {
        }

        public List<string> ACcounts
        {
            get { return this.Accounts; }
            set { ACcounts = value; }
        }

        public List<int> IDs
        {
            get { return this.IDS; }
            set { IDs = value; }
        }

        /// <summary>
        /// Method to select the hash of the specified person
        /// </summary>
        /// <param name="userID">ID value of the requested person.</param>
        /// <returns>Returns a string value containing the hash.</returns>
        public string[] SelectHash(string userID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string selectQuery = "SELECT ACTIVATIEHASH, EMAIL FROM ACCOUNT WHERE ID = :v1";
                using (OracleCommand cmd = new OracleCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("v1", userID));
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            this.hash = reader[0].ToString();
                            this.email = reader[1].ToString();
                        }
                    }
                    catch (OracleException)
                    {
                        this.counter++;
                    }
                    finally
                    {
                        if (this.counter > 0)
                        {
                            this.hash = null;
                            this.email = null;
                        }
                    }
                }
            }

            return new string[] { this.hash, this.email };
        }

        /// <summary>
        /// Method to activate the account after clicking the activation link.
        /// </summary>
        /// <param name="userID">userID value</param>
        /// <param name="hash">hash value</param>
        /// <returns>Returns an integer value to see if the activation succeeded.</returns>
        public int ActivateAccount(string userID, string hash)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                this.resultValue = 0;
                string selectQuery = "SELECT COUNT(*) FROM DUAL WHERE EXISTS (SELECT * FROM ACCOUNT WHERE ID = :v1 AND ACTIVATIEHASH = :v2)";
                using (OracleCommand cmd = new OracleCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("v1", userID));
                    cmd.Parameters.Add(new OracleParameter("v2", hash));
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            this.counter = Convert.ToInt32(reader[0]);
                        }

                        if (this.counter > 0)
                        {
                            string updateQuery = "UPDATE ACCOUNT SET GEACTIVEERD = 1 WHERE ID = :v1";
                            using (OracleCommand cmd1 = new OracleCommand(updateQuery, conn))
                            {
                                cmd1.Parameters.Add(new OracleParameter("v1", userID));
                                try
                                {
                                    cmd1.ExecuteNonQuery();
                                }
                                catch (OracleException)
                                {
                                    this.counter = 0;
                                }
                                finally
                                {
                                    if (this.counter > 0)
                                    {
                                        this.resultValue = 1;
                                    }
                                }
                            }
                        }
                    }
                    catch (OracleException)
                    {
                        this.counter = 0;
                    }

                    return this.resultValue;
                }
            }
        }

        public string GetAvailableBarcode()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string selectQuery = "SELECT BARCODE FROM POLSBANDJE WHERE ROWNUM <= 1 AND POLSBANDJE.ID NOT IN (SELECT POLSBANDJE_ID FROM RESERVERING_POLSBANDJE)";
                using (OracleCommand cmd = new OracleCommand(selectQuery, conn))
                {
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            hash = reader[0].ToString();
                        }
                    }
                    catch (OracleException)
                    {
                        this.counter = 0;
                    }
                }
            }
            return hash;
        }

        public void GenerateBarcode(string barcodes)
        {
            string barcode = barcodes;
            barcode = barcode.Replace(" ", "");
            Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font ofont = new System.Drawing.Font("IDAutomationHC39M", 20);
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString("*" + barcode + "*", ofont, black, point);
            }
            string appPath = HttpContext.Current.Request.ApplicationPath;
            string physicalPath = HttpContext.Current.Request.MapPath(appPath);
            bitmap.Save(physicalPath + "bitmap.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public void CheckAccountsAndCouple(string[] accountNames, int reservationID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                this.counter = 0;
                this.Accounts = new List<string>();
                this.IDS = new List<int>();
                foreach (string b in accountNames)
                {
                    string selectQuery = "SELECT COUNT(GEACTIVEERD) FROM ACCOUNT WHERE GEBRUIKERSNAAM = :V1 AND GEACTIVEERD = 1";
                    using (OracleCommand cmd = new OracleCommand(selectQuery, conn))
                    {
                        cmd.Parameters.Add("V1", b);
                        try
                        {
                            var reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                this.counter++;
                            }
                        }
                        catch (OracleException ex)
                        {
                            Debug.WriteLine(ErrorString(ex));
                            this.counter = 0;
                        }
                    }
                }
                if (counter == accountNames.Count())
                {
                    foreach (string b in accountNames)
                    {
                        string selectQuery1 = "SELECT ID,EMAIL FROM ACCOUNT WHERE GEBRUIKERSNAAM = :V1";
                        using (OracleCommand cmd = new OracleCommand(selectQuery1, conn))
                        {
                            cmd.Parameters.Add("V1", b);
                            try
                            {
                                var reader = cmd.ExecuteReader();
                                if (reader.Read())
                                {
                                    this.IDS.Add(Convert.ToInt32(reader[0]));
                                    this.Accounts.Add(reader[1].ToString());
                                }
                            }
                            catch (OracleException ex)
                            {
                                Debug.WriteLine(ErrorString(ex));
                                this.counter = 0;
                            }
                        }
                    }
                }
            }
            if (counter != 0)
            {
                foreach (int ids in this.IDS)
                {
                    using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
                    {
                        string barcode = GetAvailableBarcode();
                        conn.Open();
                        string selectQuery2 = "SELECT ID FROM POLSBANDJE WHERE BARCODE = :V1";
                        using (OracleCommand cmd = new OracleCommand(selectQuery2, conn))
                        {
                            cmd.Parameters.Add("V1", barcode);
                            try
                            {
                                var reader = cmd.ExecuteReader();
                                if (reader.Read())
                                {
                                    this.counter = Convert.ToInt32(reader[0]);
                                }
                            }
                            catch (OracleException ex)
                            {
                                Debug.WriteLine(ErrorString(ex));
                                this.counter = 0;
                            }
                        }
                        string insertQuery = "INSERT INTO RESERVERING_POLSBANDJE VALUES (RESERVERING_POLSBANDJE_FCSEQ.NEXTVAL,:V1,:V2,:V3,0)";
                        using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                        {
                            cmd.Parameters.Add("V1", reservationID);
                            cmd.Parameters.Add("V2", counter);
                            cmd.Parameters.Add("V3", ids);
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (OracleException ex)
                            {
                                Debug.WriteLine(ErrorString(ex));
                                this.counter = 0;
                            }
                        }
                    }
                }
            }
        }

        public string SelectBarcode(int id)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string selectQuery2 = "SELECT BARCODE FROM POLSBANDJE, RESERVERING_POLSBANDJE WHERE ACCOUNT_ID = :V1";
                using (OracleCommand cmd = new OracleCommand(selectQuery2, conn))
                {
                    cmd.Parameters.Add("V1", id);
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            this.hash = reader[0].ToString();
                        }
                    }
                    catch (OracleException ex)
                    {
                        Debug.WriteLine(ErrorString(ex));
                        this.counter = 0;
                    }
                }
            }

            return this.hash;
        }

        //public void SetBarcodes()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //    using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
        //    {
        //        conn.Open();
                
        //            try
        //            {
        //                Guid gg = Guid.NewGuid();
        //                string guid = gg.ToString().Substring(0, 10);
        //                guid = guid.ToUpper();
        //                string insertQuery = "INSERT INTO POLSBANDJE VALUES(POLSBANDJE_FCSEQ.nextval, :v1 ,1)";
        //                OracleCommand cmd = new OracleCommand(insertQuery, conn);
        //                cmd.Parameters.Add("v1", guid);
        //                cmd.Prepare();
        //                cmd.ExecuteNonQuery();
        //                conn.Close();
        //            }
        //            catch (OracleException x)
        //            {
        //                x.ToString();
        //                //retry;
        //            }
        //        }
        //    }
        //}

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
