using System.Linq;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace DI.Autofac
{
    public class ProcessorRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .Where(t => t.Name.EndsWith("Processor"))
                    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
        }
    }
}
