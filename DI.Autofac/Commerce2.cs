using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce2
    {
        public Commerce2(
            IBillingServiceLocator billingServiceLocator, 
            IInventoryService customer, 
            INotificationService notifier, 
            ILoggingService logger)
        {
            _billingServiceLocator = billingServiceLocator;
            _customer = customer;
            _notifier = notifier;
            _logger = logger;
        }

        private readonly IBillingServiceLocator _billingServiceLocator;
        private readonly IInventoryService _customer;
        private readonly INotificationService _notifier;
        private readonly ILoggingService _logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            // On-demand instantiation.
            IBillingService billingService = _billingServiceLocator.GetBillingService();

            billingService.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _logger.Log("Billing processed");
            _customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _logger.Log("Customer updated");
            _notifier.SendReceipt(orderInfo);
            _logger.Log("Receipt sent");
        }
    }
}
