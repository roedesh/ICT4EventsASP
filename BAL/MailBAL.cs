// <copyright file="MailBAL.cs" company="ICT4EventsASP">
//     Copyright (c) mailwithhmailserver. All rights reserved.
// </copyright>
// <author>Berry Verschueren</author>
namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Mail;
    using System.Net;
    using DAL;
    class MailBAL
    {
        /// <summary>
        /// Array value to work with.
        /// </summary>
        string[] returnValues;

        /// <summary>
        /// Integer value to work with.
        /// </summary>
        int counter;

        /// <summary>
        /// Initializes an instance of the MailBAL class.
        /// </summary>
        public MailBAL()
        {
            this.counter = 0;
        }

        /// <summary>
        /// Method to send an activation email to a specified emailadress.
        /// </summary>
        /// <param name="userID">userID value</param>
        /// <param name="mailto">mailto value</param>
        /// <param name="hash">hash value</param>
        /// <returns>an array with the userID, mailto, hash and an (1/0) errorOccurance index</returns>
        public string[] SendMail(string userID, string hash, string mailto)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<br /><br />   Thank you for registering at <b>PTS23</b>. <br />To complete your registration, please follow the link below:<br />");
            string link = string.Format("http://www.PTS23.com/Register.aspx?RegistrationCode={0}{1}",
                                        userID.ToString(),
                                        hash.ToString());
            sb.AppendFormat(@"<a href=""{0}"">PTS23.com Complete Registration</a>", link);
            sb.Append("<br /><br />When you have followed the link, you will be able to log in and use your account.<br />");
            sb.Append("If your email system does not allow linking, please copy and paste the following into your browser:<br />");
            sb.Append(link);
            sb.Append("<br /><br />");

            try
            {
                MailMessage msg = new MailMessage();
                msg.Subject = "Activation E-mail";
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
            }
            catch (SmtpException)
            {
                this.counter++;
            }
            finally
            {
                this.returnValues = new string[] { userID, mailto, hash, this.counter.ToString() };
            }

            return this.returnValues;
        }
    }
}
