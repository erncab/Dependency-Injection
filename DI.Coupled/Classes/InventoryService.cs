using System;

namespace DI.Coupled.Classes
{
    public class InventoryService
    {
        public void UpdateCustomerOrder(string customer, string product)
        {
            // update customer record with purchase
            Console.WriteLine("InventoryService record for '{0}' updated with purchase of product '{1}'.", customer, product);
        }
    }
}
