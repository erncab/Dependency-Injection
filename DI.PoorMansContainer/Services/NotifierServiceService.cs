using System;
using DI.PoorMansContainer.Services_Interfaces;

namespace DI.PoorMansContainer.Services
{
    public class NotifierServiceService : INotifierService
    {
        void INotifierService.SendReceipt(OrderInfo orderInfo)
        {
            // send email to inventoryService with receipt
            Console.WriteLine("Receipt sent to inventoryService '{0}' via email.", orderInfo.CustomerName);
        }
    }
}