using DI.Unity.Interfaces;

namespace DI.Unity
{
    public class Commerce2
    {
        public Commerce2(IBillingProcessorFactory billingProcessorFactory, ICustomer customer, INotifier notifier, ILogger logger)
        {
            _BillingProcessorFactory = billingProcessorFactory;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        readonly IBillingProcessorFactory _BillingProcessorFactory;
        readonly ICustomer _Customer;
        readonly INotifier _Notifier;
        readonly ILogger _Logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessor billingProcessor = _BillingProcessorFactory.GetBillingProcessor();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _Logger.Log("Billing processed");
            _Customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Logger.Log("Customer updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt sent");
        }
    }
}
