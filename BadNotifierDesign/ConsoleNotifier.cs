using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadNotifierDesign
{
    public class ConsoleNotifier
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
