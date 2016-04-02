using System;
using DI.Unity.Interfaces;

namespace DI.Unity.Classes
{
    public class Customer : ICustomer
    {
        void ICustomer.UpdateCustomerOrder(string customer, string product)
        {
            // update customer record with purchase
            Console.WriteLine("Customer record for '{0}' updated with purchase of product '{1}'.", customer, product);
        }
    }
}