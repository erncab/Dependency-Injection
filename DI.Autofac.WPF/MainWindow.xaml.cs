using System.Windows;
using Autofac;
using DI.Autofac.WPF.ViewModels;

namespace DI.Autofac.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IMainWindowViewModel viewModel = App.Container.Resolve<IMainWindowViewModel>();
            
            this.DataContext = viewModel;
        }
    }
}
