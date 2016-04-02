using DI.Coupled.Classes;

namespace DI.Coupled
{
    public class Commerce
    {
        public Commerce()
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

        readonly BillingProcessor _billingProcessor;
        readonly InventoryService _inventoryService;
        readonly Notifier _notifier;
        readonly Logger _logger;
    }
}
