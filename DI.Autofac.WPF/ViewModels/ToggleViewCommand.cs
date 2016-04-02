using System;
using System.Windows.Input;

namespace DI.Autofac.WPF.ViewModels
{
    public class ToggleViewCommand : ICommand
    {
        public ToggleViewCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        readonly MainWindowViewModel _viewModel;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _viewModel.OnToggleViewCommand();
        }
    }
}
