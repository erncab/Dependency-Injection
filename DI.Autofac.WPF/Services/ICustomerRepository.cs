using System.Collections.Generic;

namespace DI.Autofac.WPF.Services
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        List<Customer> GetAll();
        void Update(Customer customer);
    }
}
