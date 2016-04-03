namespace DI.Autofac.Interfaces
{
    public interface INotificationService
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
