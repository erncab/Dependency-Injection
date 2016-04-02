using System;
using System.ComponentModel.Composition;
using DI.MEF.Interfaces;

namespace DI.MEF.Classes
{
    [Export(typeof(IBillingProcessor))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BillingProcessor : IBillingProcessor
    {
        void IBillingProcessor.ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            Console.WriteLine("Payment processed for customer '{0}' on credit card '{1}' for {2:c}.", customer, creditCard, price);
        }
    }
}
