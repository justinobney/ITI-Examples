using Jobney.ITI.Domain;
using Jobney.ITI.Interfaces;
using Jobney.ITI.Services;
using Ninject;

namespace Jobney.ITI.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<ICallbackNotifier>().To<SmsNotifier>();

            var notifier = kernel.Get<ICallbackNotifier>();

            notifier.Subject = "Some notification";
            notifier.NotificationAddress = "2252814745";
            notifier.Message = "This is message";

            var worker = new SimpleWorker();
            worker.DoWork(notifier);
        }
    }
}