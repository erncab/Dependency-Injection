using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class NotificationProcessor : INotificationProcessor
    {
        void INotificationProcessor.SendReceipt(OrderInfo orderInfo)
        {
            // send email to customer with receipt
            Console.WriteLine("Receipt sent to customer '{0}' via email.", orderInfo.CustomerName);
        }
    }
}