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
        /// <summary>
        /// Possible types of notifications
        /// </summary>
        public enum NotificationTypes
        {
            Sms,
            Email,
            Console
        }

        /// <summary>
        /// Main Application Logic
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            // Do some really complex work here..
            // when you get done.. let the user know via a notification..

            // Ex:

            NotificationTypes notification = GetNotificationType();

            switch (notification)
            {
                case NotificationTypes.Sms:
                    SendSms();
                    break;
                case NotificationTypes.Email:
                    SendEmail();
                    break;
                case NotificationTypes.Console:
                    SendConsole();
                    break;
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Use a random number to determine what type of notification will send.
        /// In the real world this would be determined by an actual factor
        /// </summary>
        /// <returns></returns>
        private static NotificationTypes GetNotificationType()
        {
            return NotificationTypes.Console;

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

        /// <summary>
        /// This sends a notification via Email
        /// </summary>
        private static void SendEmail()
        {
            var notifier = new EmailNotifier()
                {
                    Message = "This is a message via email. It got the job done...",
                    Subject = "Email Message",
                    NotificationAddress = "justinobney@gmail.com"
                };

            notifier.SendNotification();
        }

        /// <summary>
        /// This sends a notification via Text Message
        /// </summary>
        public static void SendSms()
        {
            var notifier = new SmsNotifier()
            {
                Message = "Hello via Text..",
                Subject = "Text Message",
                NotificationAddress = "2252814745"
            };

            notifier.SendNotification();
        }

        private static void SendConsole()
        {
            var notifier = new ConsoleNotifier()
            {
                Message = "This is a message via email. It got the job done...",
                Subject = "Email Message",
                NotificationAddress = "justinobney@gmail.com"
            };

            notifier.SendNotification();
        }
    }
}
