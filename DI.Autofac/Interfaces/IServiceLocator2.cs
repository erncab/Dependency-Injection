namespace DI.Autofac.Interfaces
{
    public interface IServiceLocator2
    {
        void CreateScope();
        T GetInstance<T>();
        void ReleaseScope();
    }
}
