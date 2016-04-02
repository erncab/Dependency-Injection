using DI.Abstraction.Interfaces;

namespace DI.Abstraction
{
    public class Commerce
    {
        public Commerce(IBillingProcessor billingProcessor,
            IInventoryService inventoryService, INotifier notifier, ILogger logger)
        {
            _BillingProcessor = billingProcessor;
            _inventoryService = inventoryService;
            _Notifier = notifier;
            _Logger = logger;
        }

        readonly IBillingProcessor _BillingProcessor;
        readonly IInventoryService _inventoryService;
        readonly INotifier _Notifier;
        readonly ILogger _Logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _BillingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _Logger.Log("Billing processed");
            _inventoryService.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Logger.Log("inventoryService updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt sent");
        }
    }
}
