using DI.Coupled.Classes;

namespace DI.Coupled
{
    public class Commerce
    {
        public Commerce()
        {
            _billingProcessor = new BillingProcessor();
            _customer = new Customer();
            _notifier = new Notifier();
            _logger = new Logger();
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);

            _logger.Log("Billing processed");

            _customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);

            _logger.Log("Customer updated");

            _notifier.SendReceipt(orderInfo);

            _logger.Log("Receipt sent");
        }

        readonly BillingProcessor _billingProcessor;
        readonly Customer _customer;
        readonly Notifier _notifier;
        readonly Logger _logger;
    }
}
