﻿using System;

namespace DI.Coupled
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("COUPLED Example");
            Console.WriteLine();

            OrderInfo orderInfo = new OrderInfo()
            {
                CustomerName = "Miguel Castro",
                Email = "miguel@dotnetdude.com",
                Product = "Laptop",
                Price = 1200,
                CreditCard = "1234567890"
            };

            CommerceService commerceService = new CommerceService();

            commerceService.ProcessOrder(orderInfo);

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();
        }
    }
}