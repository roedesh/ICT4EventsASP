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

        public void GenerateBarcode()
        {
            string barcode = GetAvailableBarcode();
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
    }
}
