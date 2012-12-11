using System;
using FluentValidation;
using Jobney.ITI.Domain;
using Jobney.ITI.Domain.Validators;
using Jobney.ITI.Interfaces;
using Ninject.Modules;

namespace Jobney.ITI.ConsoleApp
{
    public class Config1 : NinjectModule
    {
        public override void Load()
        {
            Console.WriteLine("Ninject Config Module 1 Loaded");
            Kernel.Bind<ICallbackNotifier>().To<EmailNotifier>();
            Kernel.Bind<AbstractValidator<ICallbackNotifier>>().To<EmailNotifierValidator>();
        }
    }
}
