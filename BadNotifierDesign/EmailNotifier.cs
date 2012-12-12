using System;
using System.Net;
using System.Net.Mail;

namespace BadNotifierDesign
{
    public class EmailNotifier
    {

        public EmailNotifier()
        {
            Console.WriteLine("EmailNotifier Constructed.");
        }

        public string Subject { get; set; }
        public string Message { get; set; }

        public string NotificationAddress { get; set; }

        public void SendNotification()
        {
            Console.WriteLine("SendNotification has been invoked.");

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
                thisEmail.To.Add(NotificationAddress);
                thisEmail.Subject = Subject;
                thisEmail.Body = Message;
                thisEmail.IsBodyHtml = true;

                smtp.Send(thisEmail);
            }
        }
    }
}