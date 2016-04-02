using System.ServiceModel;

namespace DI.Autofac.WCF
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        void PerformOperation();
    }
}
