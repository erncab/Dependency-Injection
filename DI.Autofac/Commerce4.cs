using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce4
    {
        public Commerce4(IProcessorLocator2 processorLocator, ISingleTester singleTester)
        {
            _processorLocator = processorLocator;
            _singleTester = singleTester;
        }

        private readonly IProcessorLocator2 _processorLocator;
        private readonly ISingleTester _singleTester;

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

            _singleTester.DisplayCounter();

            //
            _processorLocator.ReleaseScope();
        }
    }

    public interface ISingleTester
    {
        void DisplayCounter();
    }

    public class SingleTester : ISingleTester
    {
        private int _counter;

        public void DisplayCounter()
        {
            _counter++;

            Console.WriteLine("Counter inside class 'SingleTester' is now: {0}", _counter);
        }
    }
}
