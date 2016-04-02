namespace DI.PoorMansContainer.Services_Interfaces
{
    public interface INotifierService
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
