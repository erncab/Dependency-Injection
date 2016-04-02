using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Classes.Plugins
{
    public class Plugin1 : IPostOrderPlugin
    {
        void IPostOrderPlugin.DoSomething()
        {
            Console.WriteLine("Plug-in #1 executed.");
        }
    }
}
