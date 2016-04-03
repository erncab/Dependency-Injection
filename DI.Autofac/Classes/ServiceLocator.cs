using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class ServiceLocator : IServiceLocator
    {
        T IServiceLocator.GetInstance<T>()
        {
            return Program.Container.Resolve<T>();
        }
    }
}