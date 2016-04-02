using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class BillingProcessorLocator : IBillingProcessorLocator
    {
        IBillingProcessor IBillingProcessorLocator.GetBillingProcessor()
        {
            return Program.Container.Resolve<IBillingProcessor>();
        }
    }
}