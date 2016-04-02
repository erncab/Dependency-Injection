using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce2
    {
        public Commerce2(IBillingProcessorLocator billingProcessorLocator, ICustomerProcessor customer, INotificationProcessor notifier, ILoggingProcessor logger)
        {
            _BillingProcessorLocator = billingProcessorLocator;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        readonly IBillingProcessorLocator _BillingProcessorLocator;
        readonly ICustomerProcessor _Customer;
        readonly INotificationProcessor _Notifier;
        readonly ILoggingProcessor _Logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessor billingProcessor = _BillingProcessorLocator.GetBillingProcessor();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _Logger.Log("Billing processed");
            _Customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Logger.Log("Customer updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt sent");
        }
    }
}
