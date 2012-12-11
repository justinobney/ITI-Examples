using System;
using FluentValidation;
using Jobney.ITI.Domain;
using Jobney.ITI.Domain.Validators;
using Jobney.ITI.Interfaces;
using Ninject.Modules;

namespace Jobney.ITI.ConsoleApp
{
    public class Config2 : NinjectModule
    {
        public override void Load()
        {
            Console.WriteLine("Ninject Config Module 1 Loaded");
            Kernel.Bind<ICallbackNotifier>().To<SmsNotifier>();
            Kernel.Bind<AbstractValidator<ICallbackNotifier>>().To<SmsNotifierValidator>();
        }
    }
}
