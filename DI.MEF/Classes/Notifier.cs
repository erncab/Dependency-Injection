using System;
using System.ComponentModel.Composition;
using DI.MEF.Interfaces;

namespace DI.MEF.Classes
{
    [Export(typeof(INotifier))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Notifier : INotifier
    {
        void INotifier.SendReceipt(OrderInfo orderInfo)
        {
            // send email to customer with receipt
            Console.WriteLine("Receipt sent to customer '{0}' via email.", orderInfo.CustomerName);
        }
    }
}