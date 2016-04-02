using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce2
    {
        public Commerce2(
            IBillingProcessorLocator billingProcessorLocator, 
            ICustomerProcessor customer, 
            INotificationProcessor notifier, 
            ILoggingProcessor logger)
        {
            _billingProcessorLocator = billingProcessorLocator;
            _customer = customer;
            _notifier = notifier;
            _logger = logger;
        }

        private readonly IBillingProcessorLocator _billingProcessorLocator;
        private readonly ICustomerProcessor _customer;
        private readonly INotificationProcessor _notifier;
        private readonly ILoggingProcessor _logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessor billingProcessor = _billingProcessorLocator.GetBillingProcessor();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);

            _logger.Log("Billing processed");

            _customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);

            _logger.Log("Customer updated");

            _notifier.SendReceipt(orderInfo);

            _logger.Log("Receipt sent");
        }
    }
}
