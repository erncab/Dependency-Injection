using System.Collections.Generic;
using DependencyInjection.Autofac.MVC.Models;

namespace DependencyInjection.Autofac.MVC.Services
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        List<Customer> GetAll();
        void Update(Customer customer);
    }
}
