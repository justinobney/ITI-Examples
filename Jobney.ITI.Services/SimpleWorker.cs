using System;
using Jobney.ITI.Interfaces;

namespace Jobney.ITI.Services
{
    public class SimpleWorker
    {
        public SimpleWorker()
        {
            Console.WriteLine("The worker has loaded");
        }

        public void DoWork(ICallbackNotifier notifier)
        {
            Console.WriteLine("DoWork method invoked");
            notifier.SendNotification();
        }
    }
}