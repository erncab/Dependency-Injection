using System;

namespace DI.Coupled.Services
{
    public class Notifier
    {
        public void SendReceipt(OrderInfo orderInfo)
        {
            // send email to customer with receipt
            Console.WriteLine("Receipt sent to customer '{0}' via email.", orderInfo.CustomerName);
        }
    }
}
