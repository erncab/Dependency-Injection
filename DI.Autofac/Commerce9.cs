using System.Collections.Generic;
using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce9
    {
        [AwesomeConstructor]
        public Commerce9(IProcessorLocator processorLocator, IEnumerable<IPostOrderPlugin> plugins)
        {
            _ProcessorLocator = processorLocator;
            _Plugins = plugins;
        }

        public Commerce9(int a, int b, int c, int d)
        {
        }

        readonly IProcessorLocator _ProcessorLocator;
        readonly IEnumerable<IPostOrderPlugin> _Plugins;
        
        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessor billingProcessor = _ProcessorLocator.GetProcessor<IBillingProcessor>();
            ICustomerProcessor customerProcessor = _ProcessorLocator.GetProcessor<ICustomerProcessor>();
            INotificationProcessor notificationProcessor = _ProcessorLocator.GetProcessor<INotificationProcessor>();
            ILoggingProcessor loggingProcessor = _ProcessorLocator.GetProcessor<ILoggingProcessor>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggingProcessor.Log("Billing processed");
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggingProcessor.Log("Customer updated");
            notificationProcessor.SendReceipt(orderInfo);
            loggingProcessor.Log("Receipt sent");

            foreach (IPostOrderPlugin plugin in _Plugins)
            {
                plugin.DoSomething();
            }
        }
    }
}