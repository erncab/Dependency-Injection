namespace DI.Autofac.Interfaces
{
    public interface IBillingProcessorLocator
    {
        IBillingService GetBillingProcessor();
    }
}