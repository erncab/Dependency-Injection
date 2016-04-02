namespace DI.PoorMansContainer.Services_Interfaces
{
    public interface IBillingProcessorService
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}
