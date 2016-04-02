using DI.Unity.Interfaces;
using Microsoft.Practices.Unity;

namespace DI.Unity.Classes
{
    public class UnityBillingProcessorFactory : IBillingProcessorFactory
    {
        IBillingProcessor IBillingProcessorFactory.GetBillingProcessor()
        {
            return Program.Container.Resolve<IBillingProcessor>();
        }
    }
}
