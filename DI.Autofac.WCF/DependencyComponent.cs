using System;

namespace DI.Autofac.WCF
{
    public class DependencyComponent : IDependency
    {
        public void ShowToConsole()
        {
            Console.WriteLine("This text was outputed from the dependency component.");
        }
    }
}
