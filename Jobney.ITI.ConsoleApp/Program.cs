using System;
using Jobney.ITI.Interfaces;
using Jobney.ITI.Services;
using Ninject;

namespace Jobney.ITI.ConsoleApp
{
    public class Program
    {
        private static void Main()
        {
            var config = new Config1();
            //var config = new Config2();

            var kernel = new StandardKernel(config);

            var notifier = kernel.Get<ICallbackNotifier>();
            notifier.Subject = "Some notification";
            notifier.NotificationAddress = "youremail@gmail.com";
            notifier.Message = "This is message";



            var worker = new SimpleWorker();
            worker.DoWork(notifier);

            Console.ReadLine();
        }
    }
}