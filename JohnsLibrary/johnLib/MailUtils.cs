using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace johnLib
{
    /// <summary>
    /// Mail Utilities for sending mail (LIB COMPLETE)
    /// </summary>
    public static class MailUtils
    {
        /// <summary>
        /// Send email without Display Name
        /// </summary>
        /// <param name="from">From Email Address - From whom</param>
        /// <param name="to">To Email Address - To whom</param>
        /// <param name="subject">Email Subject</param>
        /// <param name="body">Body content</param>
        public static bool SendMail(string from, string to, string subject, string body)
        {
            //declare returnvalue
            bool returnvalue = false;

            try //try to send mail
            {
                MailUtils.SendMail("", from, to, subject, body);
                returnvalue = true;
            }
            catch { }

            return returnvalue;
        }

        /// <summary>
        /// Send email with Display Name
        /// </summary>
        /// <param name="fromDisplayName">Display Name</param>
        /// <param name="fromEmailAddress">From Email Address - From whom</param>
        /// <param name="to">To Email Address - To whom</param>
        /// <param name="subject">Email Subject</param>
        /// <param name="body">Body content</param>
        public static bool SendMail(string fromDisplayName, string fromEmailAddress, string to, string subject, string body)
        {
            //declare return value
            bool returnValue = false;

            //create fromAddress
            MailAddress addressFrom = new MailAddress(fromEmailAddress, fromDisplayName);
            //create toAddress
            MailAddress addressTo = new MailAddress(to);
            //create new Mail message
            MailMessage email = new MailMessage(addressFrom, addressTo);
            //set mail subject
            email.Subject = subject;
            //set the view of the message
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(MailUtils.RemoveBareLineBreaks(body), null, "text/html");
            //add view to message
            email.AlternateViews.Add(htmlView);
            try //try to send email using smtp and localhost server
            {
                SmtpClient smtp = new SmtpClient("localhost");
                smtp.Send(email);
                returnValue = true;
            }
            catch
            {
            }

            return returnValue;
        }

        //this is for removing all the break line in email message
        private static string RemoveBareLineBreaks(string text)
        {
            string fullLineBreak = "\r\n";
            string bareLineBreak = "\n";
            string fullPlaceHolder = "{****FullLineBreak@@@@}";
            string barePlaceHolder = "{****BareLineBreak@@@@}";
            StringBuilder sb = new StringBuilder(text);
            sb.Replace(fullLineBreak, fullPlaceHolder).Replace(bareLineBreak, barePlaceHolder);
            sb.Replace(barePlaceHolder, fullLineBreak).Replace(fullPlaceHolder, fullLineBreak);
            return sb.ToString();
        }
    }

}
