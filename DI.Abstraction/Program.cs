using System;
using DI.Abstraction.Services;

namespace DI.Abstraction
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("ABSTRACTION Example");
            Console.WriteLine();

            OrderInfo orderInfo = new OrderInfo()
            {
                CustomerName = "Miguel Castro",
                Email = "miguel@dotnetdude.com",
                Product = "Laptop",
                Price = 1200,
                CreditCard = "1234567890"
            };

            Console.WriteLine("Production:");
            Console.WriteLine();

            CommerceService commerceService = new CommerceService(   new BillingProcessor(), 
                                                                     new InventoryService(),
                                                                     new Notifier(),
                                                                     new Logger());

            commerceService.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }
    }
}
