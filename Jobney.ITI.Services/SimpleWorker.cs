using System;
using System.Threading;
using Jobney.ITI.Interfaces;

namespace Jobney.ITI.Services
{
    public class SimpleWorker
    {
        public SimpleWorker()
        {
            Console.WriteLine("SimpleWorker Class Constructed");
        }

        public void DoWork(ICallbackNotifier notifier)
        {
            Console.WriteLine("DoWork method invoked");
            Thread.Sleep((3000));
            notifier.SendNotification();
        }
    }
}