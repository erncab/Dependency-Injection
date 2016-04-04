using System.Windows.Input;

namespace DI.Autofac.WPF.ViewModels
{
    public interface IMainWindowViewModel : IViewModel
    {
        ICommand ToggleViewCommand { get; }
        IViewModel CurrentViewModel { get; set; }
        void OnToggleViewCommand();
    }

    public class MainWindowViewModel : ViewModelBase, IViewModel, IMainWindowViewModel
    {
        public MainWindowViewModel(ICustomerListViewModel customerListViewModel,
                                   ICustomerViewModel customerViewModel)
        {
            _customerListViewModel = customerListViewModel;
            _customerViewModel = customerViewModel;
            
            CurrentViewModel = _customerListViewModel;
            ToggleViewCommand = new ToggleViewCommand(this);
        }

        private readonly ICustomerListViewModel _customerListViewModel;
        private readonly ICustomerViewModel _customerViewModel;

        private IViewModel _currentViewModel;
        
        public ICommand ToggleViewCommand { get; private set; }

        public IViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
            	_currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public void OnToggleViewCommand()
        {
            if (_currentViewModel.Equals(_customerListViewModel))
                CurrentViewModel = _customerViewModel;
            else
                CurrentViewModel = _customerListViewModel;
        }
    }
}
