/*     
 * copyright @2018 By   : Siyabonga Gregory
 * Developer's Website  : www.sgngcobo.weebly.com
 * Developer's Number   : 084-492-1275
 * Developer's E-mail   : huge.fuze@gmail.com
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Core
{
    public class CoreController
    {
        //Valiables
        string mailFrom="";
        string mailTo="";
        string password="";
        string subject="";
        string message="";


        // Mutator Methods
        public string SetMailFrom(string mailFrom)
        {
            return this.mailFrom = mailFrom;
        }
        public string SetMailTo(string mailTo)
        {
            return this.mailTo=mailTo;
        }
        public string SetPassword(string password)
        {
            return this.password = password;
        }
        public string SetSubject(string subject)
        {
            return this.subject = subject;
        }
        public string SetMessage(string message)
        {
            return this.message = message;
        }

        //Accessor Methods
        public string GetMailFrom()
        {
            return this.mailFrom;
        }
        public string GetToMail()
        {
            return this.mailTo;
        }
        public string GetPassword()
        {
            return this.password;
        }
        public string GetSubject()
        {
            return this.subject;
        }
        public string GetMessage()
        {
            return this.message;
        }

        public bool ValidateLogin() // Make sure information is provided login
        {
            if (mailFrom.ToString() != "" && password.ToString() != ""){return true;}
            else{return false;}
        }

        public bool ValidateMailFields()// Make sure information is provided sending mail
        {
            if (subject.ToString() != "" && message.ToString() != "" && mailTo.ToString() != "") { return true; } else { return false; }
        }

        public void SendMail()
        {
            var fromAddress = new MailAddress(mailFrom, "Ghost Coder");
            var toAddress = new MailAddress(mailTo, "Ghost Coder");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential(fromAddress.Address, GetPassword()),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 587,
                //Timeout = 2000
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = GetSubject(),
                Body = GetMessage()
                
            })
            {
                smtp.Send(message);
                
            }

        }

    }
}
