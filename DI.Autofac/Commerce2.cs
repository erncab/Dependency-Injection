using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce2
    {
        public Commerce2(
            IBillingProcessorLocator billingProcessorLocator, 
            IInventoryService customer, 
            INotificationService notifier, 
            ILoggingService logger)
        {
            _billingProcessorLocator = billingProcessorLocator;
            _customer = customer;
            _notifier = notifier;
            _logger = logger;
        }

        private readonly IBillingProcessorLocator _billingProcessorLocator;
        private readonly IInventoryService _customer;
        private readonly INotificationService _notifier;
        private readonly ILoggingService _logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            // On-demand instantiation.
            IBillingService billingService = _billingProcessorLocator.GetBillingProcessor();

            billingService.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _logger.Log("Billing processed");
            _customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _logger.Log("Customer updated");
            _notifier.SendReceipt(orderInfo);
            _logger.Log("Receipt sent");
        }
    }
}
