using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class BillingServiceLocator : IBillingServiceLocator
    {
        IBillingService IBillingServiceLocator.GetBillingService()
        {
            return Program.Container.Resolve<IBillingService>();
        }
    }
}