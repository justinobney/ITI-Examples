using System;
using Jobney.ITI.Domain;
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
        }
    }
}
