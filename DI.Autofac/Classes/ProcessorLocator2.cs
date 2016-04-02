using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class ProcessorLocator2 : IProcessorLocator2
    {
        public ProcessorLocator2()
        {
            ((IProcessorLocator2)this).CreateScope();
        }

        private ILifetimeScope _scope;

        void IProcessorLocator2.CreateScope()
        {
            _scope = Program.Container.BeginLifetimeScope();
        }

        T IProcessorLocator2.GetProcessor<T>()
        {
            return _scope.Resolve<T>();
        }

        void IProcessorLocator2.ReleaseScope()
        {
            _scope.Dispose();
        }
    }
}
