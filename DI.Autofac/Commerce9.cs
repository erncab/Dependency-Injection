using System.Collections.Generic;
using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce9
    {
        [AwesomeConstructor]
        public Commerce9(
            IProcessorLocator processorLocator, 
            IEnumerable<IPostOrderPlugin> plugins)
        {
            _processorLocator = processorLocator;
            _plugins = plugins;
        }

        public Commerce9(int a, int b, int c, int d)
        {
        }

        private readonly IProcessorLocator _processorLocator;
        private readonly IEnumerable<IPostOrderPlugin> _plugins;
        
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

            foreach (IPostOrderPlugin plugin in _plugins)
            {
                plugin.DoSomething();
            }
        }
    }
}
