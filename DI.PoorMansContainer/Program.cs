using System;
using DI.PoorMansContainer.DIContainer;
using DI.PoorMansContainer.Services;
using DI.PoorMansContainer.Services_Interfaces;

namespace DI.PoorMansContainer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Container container = new Container();

            container.Register<IBillingProcessorService, BillingProcessorServiceService>();
            container.Register<IInventoryService, InventoryService>();
            container.Register<INotifierService, NotifierServiceService>();
            container.Register<ILoggerService, LoggerServiceService>();

            Console.WriteLine("Poor-Man's DI Container Example");
            Console.WriteLine();

            OrderInfo orderInfo = new OrderInfo
            {
                CustomerName = "Miguel Castro",
                Email = "miguel@dotnetdude.com",
                Product = "Laptop",
                Price = 1200,
                CreditCard = "1234567890"
            };

            Console.WriteLine("Production:");
            Console.WriteLine();

            CommerceService commerceService = container.CreateType<CommerceService>();
            commerceService.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }
    }
}
