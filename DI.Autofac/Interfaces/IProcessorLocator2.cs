namespace DI.Autofac.Interfaces
{
    public interface IProcessorLocator2
    {
        void CreateScope();
        T GetProcessor<T>();
        void ReleaseScope();
    }
}
