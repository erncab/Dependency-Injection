using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce3
    {
        private readonly IServiceLocator _serviceLocator;

        public Commerce3(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            // On-demand instantiation of the processors if they're actually needed.
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
        }
    }
}
