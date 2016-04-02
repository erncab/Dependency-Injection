using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce6
    {
        public Commerce6(
            IBillingProcessor billingProcessor, 
            ICustomerProcessor customer, 
            INotificationProcessor notifier, 
            ILoggingProcessor logger)
        {
            _billingProcessor = billingProcessor;
            _customer = customer;
            _notifier = notifier;
            _logger = logger;
        }

        private readonly IBillingProcessor _billingProcessor;
        private readonly ICustomerProcessor _customer;
        private readonly INotificationProcessor _notifier;
        private readonly ILoggingProcessor _logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _logger.Log("Billing processed");
            _customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _logger.Log("Customer updated");
            _notifier.SendReceipt(orderInfo);
            _logger.Log("Receipt sent");
        }
    }
}
