using System.Collections.Generic;
using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce8
    {
        public Commerce8()
        {
            Program.Container.InjectProperties(this);
        }

        public IServiceLocator ServiceLocator { get; set; }
        public IEnumerable<IPostOrderPlugin> Plugins { get; set; }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingService billingService = ServiceLocator.GetInstance<IBillingService>();
            IInventoryService inventoryService = ServiceLocator.GetInstance<IInventoryService>();
            INotificationService notificationService = ServiceLocator.GetInstance<INotificationService>();
            ILoggingService loggingService = ServiceLocator.GetInstance<ILoggingService>();

            billingService.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggingService.Log("Billing processed");
            inventoryService.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggingService.Log("Customer updated");
            notificationService.SendReceipt(orderInfo);
            loggingService.Log("Receipt sent");

            foreach (IPostOrderPlugin plugin in Plugins)
            {
                plugin.DoSomething();
            }
        }
    }
}
