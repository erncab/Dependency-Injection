using DI.PoorMansContainer.Services_Interfaces;

namespace DI.PoorMansContainer
{
    public class CommerceService
    {
        public CommerceService(
            IBillingProcessorService billingProcessorService, 
            IInventoryService inventoryService, 
            INotifierService notifierService, 
            ILoggerService loggerService)
        {
            _billingProcessorService = billingProcessorService;
            _inventoryService = inventoryService;
            _notifierService = notifierService;
            _loggerService = loggerService;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _billingProcessorService.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            
            _loggerService.Log("Billing processed");
            
            _inventoryService.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            
            _loggerService.Log("inventoryService updated");
            
            _notifierService.SendReceipt(orderInfo);
            
            _loggerService.Log("Receipt sent");
        }

        private readonly IBillingProcessorService _billingProcessorService;
        private readonly IInventoryService _inventoryService;
        private readonly INotifierService _notifierService;
        private readonly ILoggerService _loggerService;
    }
}
