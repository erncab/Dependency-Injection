using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes.Plugins
{
    public class Plugin3 : IPostOrderPlugin
    {
        void IPostOrderPlugin.DoSomething()
        {
            Console.WriteLine("Plug-in #3 executed.");
        }
    }
}
