using System;
using System.Net;
using System.Net.Mail;

namespace BadNotifierDesign
{
    public class SmsNotifier
    {

        public SmsNotifier()
        {
            Console.WriteLine("SmsNotifier Constructed.");
        }

        private string _notificationAddress;
        public string Subject { get; set; }
        public string Message { get; set; }

        public string NotificationAddress
        {
            get { return _notificationAddress; }
            set
            {
                _notificationAddress = !string.IsNullOrEmpty(value) ? value : "";
            }
        }

        private string GetNotificationAddress
        {
            get
            {
                if (!_notificationAddress.EndsWith("@txt.att.net"))
                {
                    return _notificationAddress + "@txt.att.net";
                }
                else
                {
                    return _notificationAddress;
                }
            }
        }

        public void SendNotification()
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
                thisEmail.To.Add(GetNotificationAddress);
                thisEmail.Subject = Subject;
                thisEmail.Body = Message;
                thisEmail.IsBodyHtml = true;

                smtp.Send(thisEmail);
            }
        }
    }
}
