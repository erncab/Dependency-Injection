using System.Collections.Generic;
using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce7
    {
        public Commerce7(
            IServiceLocator serviceLocator, 
            IEnumerable<IPostOrderPlugin> plugins)
        {
            _serviceLocator = serviceLocator;
            _plugins = plugins;
        }

        private readonly IServiceLocator _serviceLocator;
        private readonly IEnumerable<IPostOrderPlugin> _plugins;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingService billingService = _serviceLocator.GetInstance<IBillingService>();
            IInventoryService inventoryService = _serviceLocator.GetInstance<IInventoryService>();
            INotificationService notificationService = _serviceLocator.GetInstance<INotificationService>();
            ILoggingService loggingService = _serviceLocator.GetInstance<ILoggingService>();

            billingService.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggingService.Log("Billing processed");
            inventoryService.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggingService.Log("Customer updated");
            notificationService.SendReceipt(orderInfo);
            loggingService.Log("Receipt sent");

            foreach (IPostOrderPlugin plugin in _plugins)
            {
                plugin.DoSomething();
            }
        }
    }
}
