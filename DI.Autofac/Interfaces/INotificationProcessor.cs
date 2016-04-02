namespace DI.Autofac.Interfaces
{
    public interface INotificationProcessor
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
