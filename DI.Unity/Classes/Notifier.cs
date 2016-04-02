using System;
using DI.Unity.Interfaces;

namespace DI.Unity.Classes
{
    public class Notifier : INotifier
    {
        void INotifier.SendReceipt(OrderInfo orderInfo)
        {
            // send email to customer with receipt
            Console.WriteLine("Receipt sent to customer '{0}' via email.", orderInfo.CustomerName);
        }
    }
}