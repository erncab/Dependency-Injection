namespace DI.Autofac.Interfaces
{
    public interface IBillingService
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}