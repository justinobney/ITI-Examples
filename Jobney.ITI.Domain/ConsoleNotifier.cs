using System;
using Jobney.ITI.Interfaces;

namespace Jobney.ITI.Domain
{
    public class ConsoleNotifier : ICallbackNotifier
    {
        public string Message { get; set; }

        public string Subject { get; set; }

        public string NotificationAddress { get; set; }

        public void SendNotification()
        {
            Console.WriteLine("To: " + NotificationAddress);
            Console.WriteLine("Subject: " + Subject);
            Console.WriteLine("Message: " + Message);
        }
    }
}
