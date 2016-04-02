using DI.Abstraction.Interfaces;

namespace DI.Abstraction
{
    public class Commerce
    {
        public Commerce(
            IBillingProcessor billingProcessor,
            IInventoryService inventoryService, 
            INotifier notifier, 
            ILogger logger)
        {
            _billingProcessor = billingProcessor;
            _inventoryService = inventoryService;
            _notifier = notifier;
            _logger = logger;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            
            _logger.Log("Billing processed");
            
            _inventoryService.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            
            _logger.Log("inventoryService updated");
            
            _notifier.SendReceipt(orderInfo);
            
            _logger.Log("Receipt sent");
        }

        readonly IBillingProcessor _billingProcessor;
        readonly IInventoryService _inventoryService;
        readonly INotifier _notifier;
        readonly ILogger _logger;
    }
}
