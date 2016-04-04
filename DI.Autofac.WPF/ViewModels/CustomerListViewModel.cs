using System.Collections.Generic;
using DI.Autofac.WPF.Services;

namespace DI.Autofac.WPF.ViewModels
{
    public interface ICustomerListViewModel : IViewModel
    {
        List<Customer> CustomersModel { get; }
    }

    public class CustomerListViewModel : ViewModelBase, ICustomerListViewModel
    {
        public CustomerListViewModel(ICustomerRepository customerRepository)
        {
            _customersModel = customerRepository.GetAll();
        }

        private readonly List<Customer> _customersModel;

        public List<Customer> CustomersModel
        {
            get { return _customersModel; }
        }
    }
}
