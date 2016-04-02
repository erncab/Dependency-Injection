using DI.Coupled.Services;

namespace DI.Coupled
{
    public class CommerceService
    {
        public CommerceService()
        {
            _billingProcessor = new BillingProcessor();
            _inventoryService = new InventoryService();
            _notifier = new Notifier();
            _logger = new Logger();
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);

            _logger.Log("Billing processed");

            _inventoryService.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);

            _logger.Log("InventoryService updated");

            _notifier.SendReceipt(orderInfo);

            _logger.Log("Receipt sent");
        }

        private readonly BillingProcessor _billingProcessor;
        private readonly InventoryService _inventoryService;
        private readonly Notifier _notifier;
        private readonly Logger _logger;
    }
}
