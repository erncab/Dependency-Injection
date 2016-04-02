using DI.Autofac.WPF.Services;

namespace DI.Autofac.WPF.ViewModels
{
    public interface ICustomerViewModel : IViewModel
    {
        Customer CustomerModel { get; }
    }
    
    public class CustomerViewModel : ViewModelBase, ICustomerViewModel
    {
        public CustomerViewModel(ICustomerRepository customerRepository)
        {
            _customerModel = customerRepository.GetById(1);
        }

        readonly Customer _customerModel;

        public Customer CustomerModel
        {
            get { return _customerModel; }
        }
    }
}
