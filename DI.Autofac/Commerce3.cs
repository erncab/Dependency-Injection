using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce3
    {
        public Commerce3(IProcessorLocator processorLocator)
        {
            _processorLocator = processorLocator;
        }

        private readonly IProcessorLocator _processorLocator;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessor billingProcessor = _processorLocator.GetProcessor<IBillingProcessor>();
            ICustomerProcessor customerProcessor = _processorLocator.GetProcessor<ICustomerProcessor>();
            INotificationProcessor notificationProcessor = _processorLocator.GetProcessor<INotificationProcessor>();
            ILoggingProcessor loggingProcessor = _processorLocator.GetProcessor<ILoggingProcessor>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);

            loggingProcessor.Log("Billing processed");

            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);

            loggingProcessor.Log("Customer updated");

            notificationProcessor.SendReceipt(orderInfo);

            loggingProcessor.Log("Receipt sent");
        }
    }
}
