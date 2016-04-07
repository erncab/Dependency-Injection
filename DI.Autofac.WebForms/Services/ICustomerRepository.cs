using System.Collections.Generic;
using DI.Autofac.WebForms.Models;

namespace DI.Autofac.WebForms.Services
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        List<Customer> GetAll();
        void Update(Customer customer);
    }
}
