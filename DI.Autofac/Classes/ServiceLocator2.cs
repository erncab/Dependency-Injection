using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class ServiceLocator2 : IServiceLocator2
    {
        private ILifetimeScope _scope;

        void IServiceLocator2.CreateScope()
        {
            _scope = Program.Container.BeginLifetimeScope();
        }

        public ServiceLocator2()
        {
            ((IServiceLocator2)this).CreateScope();
        }

        T IServiceLocator2.GetInstance<T>()
        {
            return _scope.Resolve<T>();
        }

        void IServiceLocator2.ReleaseScope()
        {
            _scope.Dispose();
        }
    }
}
