using System.ComponentModel.Composition;
using System.Windows.Input;

namespace DI.MEF.WPF.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainWindowViewModel : ViewModelBase, IPartImportsSatisfiedNotification
    {
        public MainWindowViewModel()
        {
            ToggleViewCommand = new ToggleViewCommand(this);
        }

        [Import]
        CustomerListViewModel _customerListViewModel;

        [Import]
        CustomerViewModel _customerViewModel;

        ViewModelBase _currentViewModel;

        public ICommand ToggleViewCommand { get; private set; }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
            	_currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        internal void OnToggleViewCommand()
        {
            if (_currentViewModel.Equals(_customerListViewModel))
                CurrentViewModel = _customerViewModel;
            else
                CurrentViewModel = _customerListViewModel;
        }

        public void OnImportsSatisfied()
        {
            CurrentViewModel = _customerListViewModel;
        }
    }
}
