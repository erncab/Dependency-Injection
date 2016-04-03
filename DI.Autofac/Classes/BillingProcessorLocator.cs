using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class BillingProcessorLocator : IBillingProcessorLocator
    {
        IBillingService IBillingProcessorLocator.GetBillingProcessor()
        {
            return Program.Container.Resolve<IBillingService>();
        }
    }
}