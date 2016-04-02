using System.ComponentModel.Composition;
using DI.MEF.WPF.Services;

namespace DI.MEF.WPF.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerViewModel : ViewModelBase
    {
        [ImportingConstructor]
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