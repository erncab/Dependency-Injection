using System.Collections.Generic;
using System.ComponentModel.Composition;
using DI.MEF.WPF.Services;

namespace DI.MEF.WPF.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerListViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public CustomerListViewModel(ICustomerRepository customerRepository)
        {
            _customersModel = customerRepository.GetAll();
        }

        readonly List<Customer> _customersModel;

        public List<Customer> CustomersModel
        {
            get { return _customersModel; }
        }
    }
}
