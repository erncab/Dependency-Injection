using System.Collections.Generic;
using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce8
    {
        public Commerce8()
        {
            //Program.Container.InjectProperties(this);
        }

        public IProcessorLocator ProcessorLocator { get; set; }
        public IEnumerable<IPostOrderPlugin> Plugins { get; set; }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessor billingProcessor = ProcessorLocator.GetProcessor<IBillingProcessor>();
            ICustomerProcessor customerProcessor = ProcessorLocator.GetProcessor<ICustomerProcessor>();
            INotificationProcessor notificationProcessor = ProcessorLocator.GetProcessor<INotificationProcessor>();
            ILoggingProcessor loggingProcessor = ProcessorLocator.GetProcessor<ILoggingProcessor>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggingProcessor.Log("Billing processed");
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggingProcessor.Log("Customer updated");
            notificationProcessor.SendReceipt(orderInfo);
            loggingProcessor.Log("Receipt sent");

            foreach (IPostOrderPlugin plugin in Plugins)
            {
                plugin.DoSomething();
            }
        }
    }
}
