using System;
using DI.PoorMansContainer.Services_Interfaces;

namespace DI.PoorMansContainer.Services
{
    public class BillingProcessorServiceService : IBillingProcessorService
    {
        void IBillingProcessorService.ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            Console.WriteLine("Payment processed for inventoryService '{0}' on credit card '{1}' for {2:c}.", customer, creditCard, price);
        }
    }
}
