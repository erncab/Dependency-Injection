using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac
{
    public class Commerce4
    {
        private readonly IServiceLocator2 _iaaaServiceLocator;
        private readonly ISingleTester _singleTester;

        public Commerce4(IServiceLocator2 iaaaServiceLocator, ISingleTester singleTester)
        {
            _iaaaServiceLocator = iaaaServiceLocator;
            _singleTester = singleTester;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingService billingService = _iaaaServiceLocator.GetInstance<IBillingService>();
            IInventoryService inventoryService = _iaaaServiceLocator.GetInstance<IInventoryService>();
            INotificationService notificationService = _iaaaServiceLocator.GetInstance<INotificationService>();
            ILoggingService loggingService = _iaaaServiceLocator.GetInstance<ILoggingService>();

            billingService.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggingService.Log("Billing processed");
            inventoryService.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggingService.Log("Customer updated");
            notificationService.SendReceipt(orderInfo);
            loggingService.Log("Receipt sent");

            _singleTester.DisplayCounter();

            //
            _iaaaServiceLocator.ReleaseScope();
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
