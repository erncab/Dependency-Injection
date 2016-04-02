using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce1
    {
        public Commerce1(IBillingProcessor billingProcessor, ICustomerProcessor customer, INotificationProcessor notifier, ILoggingProcessor logger)
        {
            _BillingProcessor = billingProcessor;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        readonly IBillingProcessor _BillingProcessor;
        readonly ICustomerProcessor _Customer;
        readonly INotificationProcessor _Notifier;
        readonly ILoggingProcessor _Logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _BillingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _Logger.Log("Billing processed");
            _Customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Logger.Log("Customer updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt sent");
        }
    }
}
