using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BadNotifierDesign
{
    class Program
    {
        public enum NotificationTypes
        {
            Sms,
            Email
        }

        static void Main(string[] args)
        {
            NotificationTypes notification = GetNotificationType();

            switch (notification)
            {
                case NotificationTypes.Sms:
                    SendSms();
                    break;
                case NotificationTypes.Email:
                    SendEmail();
                    break;
            }

            Console.ReadLine();
        }

        private static NotificationTypes GetNotificationType()
        {
            if (new Random().Next(5)%2 == 1)
            {
                Console.WriteLine("SMS Coming your way..");
                return NotificationTypes.Sms;
            }
            else
            {
                Console.WriteLine("Good ole faithful email...");
                return NotificationTypes.Email;
            }
        }

        private static void SendEmail()
        {
            var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("gsender1@gmail.com", "sendmail"),
                    EnableSsl = true
                };

            using (var thisEmail = new MailMessage())
            {
                thisEmail.From = new MailAddress("gsender1@gmail.com", "My Email Sender");
                thisEmail.To.Add("youremail@gmail.com");
                thisEmail.Subject = "Email Message";
                thisEmail.Body = "This is a message via email. It got the job done...";
                thisEmail.IsBodyHtml = true;

                smtp.Send(thisEmail);
            }
        }

        public static void SendSms()
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("gsender1@gmail.com", "sendmail"),
                EnableSsl = true
            };

            using (var thisEmail = new MailMessage())
            {
                thisEmail.From = new MailAddress("gsender1@gmail.com", "My SMS Sender");
                thisEmail.To.Add("1234567890@txt.att.net");
                thisEmail.Subject = "Via SMS";
                thisEmail.Body = "Txting via code.";
                thisEmail.IsBodyHtml = true;

                smtp.Send(thisEmail);
            }
        }
    }
}
