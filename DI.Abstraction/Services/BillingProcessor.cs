using System;
using DI.Abstraction.Services_Interfaces;

namespace DI.Abstraction.Services
{
    public class BillingProcessor : IBillingProcessor
    {
        void IBillingProcessor.ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            Console.WriteLine("Payment processed for inventoryService '{0}' on credit card '{1}' for {2:c}.", customer, creditCard, price);
        }
    }
}
