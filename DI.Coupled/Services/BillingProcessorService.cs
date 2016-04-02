using System;

namespace DI.Coupled.Services
{
    public class BillingProcessorService
    {
        public void ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            Console.WriteLine("Payment processed for customer '{0}' on credit card '{1}' for {2:c}.", customer, creditCard, price);
        }
    }
}
