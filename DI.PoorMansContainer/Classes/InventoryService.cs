using System;
using DI.PoorMansContainer.Interfaces;

namespace DI.PoorMansContainer.Classes
{
    public class InventoryService : IInventoryService
    {
        void IInventoryService.UpdateCustomerOrder(string customer, string product)
        {
            // update inventoryService record with purchase
            Console.WriteLine("inventoryService record for '{0}' updated with purchase of product '{1}'.", customer, product);
        }
    }
}