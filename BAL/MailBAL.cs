// <copyright file="MailBAL.cs" company="ICT4EventsASP">
//     Copyright (c) mailwithhmailserver. All rights reserved.
// </copyright>
// <author>Berry Verschueren</author>
namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;    
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using DAL;

    /// <summary>
    /// Class for mail business
    /// </summary>
    public class MailBAL
    {
        /// <summary>
        /// field for mail instance
        /// </summary>
        private MailDAL maildal;

        /// <summary>
        /// Array value to work with.
        /// </summary>
        private string[] returnValues;

        /// <summary>
        /// Integer value to work with.
        /// </summary>
        private int counter;

        /// <summary>
        /// Boolean value indicating whether it's an activation e-mail or not.
        /// </summary>
        private bool activation;

        /// <summary>
        /// File stream to use for attachments.
        /// </summary> 
        private FileStream fs;

        /// <summary>
        /// string for mail to value
        /// </summary>
        private string mailto;

        /// <summary>
        /// string for hash value
        /// </summary>
        private string hash;

        /// <summary>
        /// Initializes a new instance of the MailBAL class
        /// </summary>
        /// <param name="activation">activation mail boolean</param>
        public MailBAL(bool activation)
        {
            this.activation = activation;
            this.counter = 0;
        }

        /// <summary>
        /// Method to send an activation email to a specified email address.
        /// </summary>
        /// <param name="userID">userID value</param>
        /// <param name="usernames">usernames array</param>
        /// <param name="reservationID">reservation id value</param>
        /// <returns>Returns a list of results.</returns>
        public string[] SendMail(string userID, string[] usernames, int reservationID)
        {
            if (usernames != null && reservationID != 0)
            {
                this.maildal = this.CheckAccountsAndCouple(usernames, reservationID);
            }
            else
            {
                this.maildal = new MailDAL();
            }

            StringBuilder sb = new StringBuilder();
                MailMessage msg = new MailMessage();
            if (this.activation)
            {
                string[] personData = this.maildal.SelectHash(userID);
            if (personData[0] == null && personData[1] == null)
            {
                return null;
            }

            this.hash = personData[0];
            this.mailto = personData[1];
            
                sb.AppendFormat("<br /><br />   Thank you for registering at <b>PTS23</b>. <br />To complete your registration, please follow the link below:<br />");
                string link = string.Format(
                    "http://pts23.com/Registreren.aspx?RegistrationCode={1}&AccountID={0}", userID.ToString(), this.hash.ToString());
                sb.AppendFormat(@"<a href=""{0}"">PTS23.com Complete Registration</a>", link);
                sb.Append("<br /><br />When you have followed the link, you will be able to log in and use your account.<br />");
                sb.Append("If your email system does not allow linking, please copy and paste the following into your browser:<br />");
                sb.Append(link);
                sb.Append("<br /><br />");
                msg.Subject = "Activation E-mail";
            } 

                    if (!this.activation)
                    {
                        string appPath = HttpContext.Current.Request.ApplicationPath;
                        string physicalPath = HttpContext.Current.Request.MapPath(appPath);
                        this.counter = 0;
                        foreach (int id in this.maildal.IDs)
                        {
                            string barcode = this.maildal.SelectBarcode(id);
                            this.maildal.GenerateBarcode(barcode);
                            using (this.fs = File.Open(physicalPath + "bitmap.jpeg", FileMode.Open))
                            {                         
                                msg = new MailMessage();
                                msg.Attachments.Add(new Attachment(this.fs, new ContentType(MediaTypeNames.Image.Jpeg)));
                                sb.Clear();
                                sb.Append("<br /><br /> Thank you for placing your reservation. " +
                                    "<br /><br />Please make sure to bring the attached <b>barcode</b> with you," +
                                    "<br />you will have to show this at the entrance of the event." +
                                    "<br />A digital version is also allowed, i.e. showing us this e-mail." +
                                    "<br />See you there!");
                                msg.Subject = "Reservation E-mail";
                                msg.From = new MailAddress("fontyspts23@gmail.com");
                                msg.Body = sb.ToString();
                                msg.To.Add(new MailAddress(this.maildal.Accounts[this.counter]));
                                msg.IsBodyHtml = true;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.Port = 587;
                                smtp.UseDefaultCredentials = false;
                                smtp.EnableSsl = true;
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                NetworkCredential loginCredentials = new NetworkCredential("fontyspts23@gmail.com", "PTS23PTS23");
                                smtp.Credentials = loginCredentials;
                                smtp.Send(msg);
                                this.fs.Close();
                                this.counter++;
                            }
                        }
                    }        
            
                    if (this.activation)
                    {
                        msg.From = new MailAddress("fontyspts23@gmail.com");
                        msg.Body = sb.ToString();
                        msg.To.Add(new MailAddress(this.mailto));
                        msg.IsBodyHtml = true;
                        SmtpClient smtp1 = new SmtpClient();
                        smtp1.Host = "smtp.gmail.com";
                        smtp1.Port = 587;
                        smtp1.UseDefaultCredentials = false;
                        smtp1.EnableSsl = true;
                        smtp1.DeliveryMethod = SmtpDeliveryMethod.Network;
                        NetworkCredential loginCredentials1 = new NetworkCredential("fontyspts23@gmail.com", "PTS23PTS23");
                        smtp1.Credentials = loginCredentials1;
                        smtp1.Send(msg);
                    }

                    if (!this.activation)
                    {
                        string appP = HttpContext.Current.Request.ApplicationPath;
                        string physicalP = HttpContext.Current.Request.MapPath(appP);
                        File.Delete(physicalP + "bitmap.jpeg");
                    }

                    this.returnValues = new string[] { userID, this.mailto, this.hash, this.counter.ToString() };

            return this.returnValues;
        }

        /// <summary>
        /// Activate the specified account by checking the hash.
        /// </summary>
        /// <param name="userID">userID value</param>
        /// <param name="hash">hash value</param>
        /// <returns>Returns the result of the method.</returns>
        public bool ActivateAccount(string userID, string hash)
        {
            MailDAL maildal = new MailDAL();
            int succesnumber = maildal.ActivateAccount(userID, hash);
            AccountDAL accountdal = new AccountDAL();
            string[] accountData = accountdal.Load(Convert.ToInt32(userID));
            ActiveDirectoryBAL adbal = new ActiveDirectoryBAL();
            string[] returnData = adbal.EnableAccount(accountData[0]);
            if (returnData[1] != "0")
            {
                succesnumber = 0;
            }
            return succesnumber == 0 ? false : true;
        }

        ////public void InsertValuesPolsbandje()
        ////{
        ////    MailDAL maildal = new MailDAL();
        ////}

        /// <summary>
        /// method to couple accounts to a reservation.
        /// </summary>
        /// <param name="usernames">username value</param>
        /// <param name="reservationID">reservation id value</param>
        /// <returns>return mail instance</returns>
        public MailDAL CheckAccountsAndCouple(string[] usernames, int reservationID)
        {
            return new MailDAL().CheckAccountsAndCouple(usernames, reservationID);
        }
    }
}
