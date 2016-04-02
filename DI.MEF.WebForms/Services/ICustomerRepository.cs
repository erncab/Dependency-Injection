using System.Collections.Generic;
using DI.MEF.WebForms.Models;

namespace DI.MEF.WebForms.Services
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        List<Customer> GetAll();
        void Update(Customer customer);
    }
}
