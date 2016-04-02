using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;

namespace DI.MEF.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CompositionContainer Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            Container = new CompositionContainer(catalog);

            base.OnStartup(e);
        }
    }
}
