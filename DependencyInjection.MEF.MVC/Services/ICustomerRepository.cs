using System.Collections.Generic;
using DependencyInjection.MEF.MVC.Models;

namespace DependencyInjection.MEF.MVC.Services
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        List<Customer> GetAll();
        void Update(Customer customer);
    }
}
