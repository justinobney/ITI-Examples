using System;
using FluentValidation;
using Jobney.ITI.Interfaces;
using Jobney.ITI.Services;
using Ninject;

namespace Jobney.ITI.ConsoleApp
{
    public static class Program
    {
        private static void Main()
        {
            var config = new Config1();
            //var config = new Config2();

            var kernel = new StandardKernel(config);

            var notifier = kernel.Get<ICallbackNotifier>();
            var validator = kernel.Get<AbstractValidator<ICallbackNotifier>>();

            notifier.Subject = "Some notification";
            notifier.NotificationAddress = "2252814745";
            notifier.Message = "This is message";

            var result = validator.Validate(notifier);

            if (result.IsValid)
            {
                var worker = new SimpleWorker();
                worker.DoWork(notifier);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            Console.ReadLine();
        }
    }
}