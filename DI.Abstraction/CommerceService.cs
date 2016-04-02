using DI.Abstraction.Services_Interfaces;

namespace DI.Abstraction
{
    public class CommerceService
    {
        public CommerceService(
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

        private readonly IBillingProcessor _billingProcessor;
        private readonly IInventoryService _inventoryService;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
    }
}
