namespace DI.Autofac.Interfaces
{
    public interface IProcessorLocator
    {
        T GetProcessor<T>();
    }
}