using DI.Coupled.Services;

namespace DI.Coupled
{
    public class CommerceService
    {
        public CommerceService()
        {
            _billingProcessorService = new BillingProcessorService();
            _inventoryService = new InventoryService();
            _notifierService = new NotifierService();
            _loggerService = new LoggerService();
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _billingProcessorService.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);

            _loggerService.Log("Billing processed");

            _inventoryService.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);

            _loggerService.Log("InventoryService updated");

            _notifierService.SendReceipt(orderInfo);

            _loggerService.Log("Receipt sent");
        }

        private readonly BillingProcessorService _billingProcessorService;
        private readonly InventoryService _inventoryService;
        private readonly NotifierService _notifierService;
        private readonly LoggerService _loggerService;
    }
}
