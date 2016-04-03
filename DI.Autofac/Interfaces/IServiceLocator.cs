namespace DI.Autofac.Interfaces
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
    }
}