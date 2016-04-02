using System.Windows;
using DI.MEF.WPF.ViewModels;

namespace DI.MEF.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainWindowViewModel viewModel =
                App.Container.GetExportedValue<MainWindowViewModel>();
            this.DataContext = viewModel;
        }
    }
}
