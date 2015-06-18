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

    public class MailBAL
    {
        /// <summary>
        /// Array value to work with.
        /// </summary>
        private string[] returnValues;

        /// <summary>
        /// Integer value to work with.
        /// </summary>
        private int counter;

        /// <summary>
        /// Boolean value indictating whether it's an activation e-mail or not.
        /// </summary>
        private bool activation;

        /// <summary>
        /// Filestream to use for attachments.
        /// </summary>
        private FileStream fs;

        /// <summary>
        /// Initializes an instance of the MailBAL class.
        /// </summary>
        public MailBAL(bool activation)
        {
            this.activation = activation;
            this.counter = 0;
        }

        /// <summary>
        /// Method to send an activation email to a specified email address.
        /// </summary>
        /// <param name="userID">userID value</param>
        /// <param name="mailto">mailto value</param>
        /// <param name="hash">hash value</param>
        /// <returns>an array with the userID, mailto, hash and an (1/0) error index</returns>
        public string[] SendMail(string userID)
        {
            MailDAL maildal = new MailDAL();
            string[] personData = maildal.SelectHash(userID);
            if (personData[0] == null && personData[1] == null)
            {
                return null;
            }

            string hash = personData[0];
            string mailto = personData[1];
            StringBuilder sb = new StringBuilder();
            if (activation)
            {
                sb.AppendFormat("<br /><br />   Thank you for registering at <b>PTS23</b>. <br />To complete your registration, please follow the link below:<br />");
                string link = string.Format(
                    "http://localhost:2359/Registreren.aspx?RegistrationCode={1}&AccountID={0}", userID.ToString(), hash.ToString());
                sb.AppendFormat(@"<a href=""{0}"">PTS23.com Complete Registration</a>", link);
                sb.Append("<br /><br />When you have followed the link, you will be able to log in and use your account.<br />");
                sb.Append("If your email system does not allow linking, please copy and paste the following into your browser:<br />");
                sb.Append(link);
                sb.Append("<br /><br />");
            }

            try
            {
                MailMessage msg = new MailMessage();
                msg.Subject = "Activation E-mail";
                    string appPath = HttpContext.Current.Request.ApplicationPath;
                    string physicalPath = HttpContext.Current.Request.MapPath(appPath);
                    foreach (int id in maildal.IDs)
                    {
                        string barcode = maildal.SelectBarcode(id);
                        maildal.GenerateBarcode(barcode);
                        using (fs = File.Open(physicalPath + "bitmap.jpeg", FileMode.Open))
                        {
                            if (!activation)
                            {
                                msg.Attachments.Add(new Attachment(fs, new ContentType(MediaTypeNames.Image.Jpeg)));
                                sb.Clear();
                                sb.Append("<br /><br /> Thank you for placing your reservation. " +
                                   "<br /><br />Please make sure to bring the attached <b>barcode</b> with you," +
                                   "<br />you will have to show this at the entrance of the event." +
                                   "<br />A digital version is also allowed, i.e. showing us this e-mail." +
                                   "<br />See you there!");
                                msg.Subject = "Reservation E-mail";
                                msg.From = new MailAddress("fontyspts23@gmail.com");
                                msg.Body = sb.ToString();
                                msg.To.Add(new MailAddress(mailto));
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
                                fs.Close();
                            }
                        }
                    }
                    if (activation)
                    {
                        msg.From = new MailAddress("fontyspts23@gmail.com");
                        msg.Body = sb.ToString();
                        msg.To.Add(new MailAddress(mailto));
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
                    if (!activation)
                    {
                        string appP = HttpContext.Current.Request.ApplicationPath;
                        string physicalP = HttpContext.Current.Request.MapPath(appP);
                        File.Delete(physicalP + "bitmap.jpeg");
                    }
            }
            catch (SmtpException x)
            {
                x.ToString();
                this.counter++;
            }
            finally
            {
                this.returnValues = new string[] { userID, mailto, hash, this.counter.ToString() };
            }

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
            return succesnumber == 0 ? false : true;
        }

        //public void InsertValuesPolsbandje()
        //{
        //    MailDAL maildal = new MailDAL();
        //}
    }
}
