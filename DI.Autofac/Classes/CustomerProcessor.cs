using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class CustomerProcessor : ICustomerProcessor
    {
        void ICustomerProcessor.UpdateCustomerOrder(string customer, string product)
        {
            // update customer record with purchase
            Console.WriteLine("Customer record for '{0}' updated with purchase of product '{1}'.", customer, product);
        }
    }
}