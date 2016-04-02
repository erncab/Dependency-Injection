using System;
using DI.Abstraction.Services_Interfaces;

namespace DI.Abstraction.Services
{
    public class Notifier : INotifier
    {
        void INotifier.SendReceipt(OrderInfo orderInfo)
        {
            // send email to inventoryService with receipt
            Console.WriteLine("Receipt sent to inventoryService '{0}' via email.", orderInfo.CustomerName);
        }
    }
}