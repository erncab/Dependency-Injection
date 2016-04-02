using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes
{
    public class ProcessorLocator : IProcessorLocator
    {
        T IProcessorLocator.GetProcessor<T>()
        {
            return Program.Container.Resolve<T>();
        }
    }
}