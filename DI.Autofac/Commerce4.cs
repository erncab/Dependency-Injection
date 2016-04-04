using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce4
    {
        private readonly IServiceLocator2 _serviceLocator;
        private readonly ISingleTester _singleTester;

        public Commerce4(IServiceLocator2 serviceLocator, ISingleTester singleTester)
        {
            _serviceLocator = serviceLocator;
            _singleTester = singleTester;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingService billingService = _serviceLocator.GetInstance<IBillingService>();
            IInventoryService inventoryService = _serviceLocator.GetInstance<IInventoryService>();
            INotificationService notificationService = _serviceLocator.GetInstance<INotificationService>();
            ILoggingService loggingService = _serviceLocator.GetInstance<ILoggingService>();

            billingService.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggingService.Log("Billing processed");
            inventoryService.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggingService.Log("Customer updated");
            notificationService.SendReceipt(orderInfo);
            loggingService.Log("Receipt sent");

            _singleTester.DisplayCounter();

            //
            _serviceLocator.ReleaseScope();
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
