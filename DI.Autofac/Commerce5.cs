using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce5
    {
        public Commerce5(
            IBillingService billingService, 
            IInventoryService customer, 
            INotificationService notifier, 
            ILoggingService logger)
        {
            _billingService = billingService;
            _customer = customer;
            _notifier = notifier;
            _logger = logger;
        }

        private readonly IBillingService _billingService;
        private readonly IInventoryService _customer;
        private readonly INotificationService _notifier;
        private readonly ILoggingService _logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _billingService.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _logger.Log("Billing processed");
            _customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _logger.Log("Customer updated");
            _notifier.SendReceipt(orderInfo);
            _logger.Log("Receipt sent");
        }
    }
}
