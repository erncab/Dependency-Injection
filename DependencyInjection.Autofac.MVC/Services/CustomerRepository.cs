using System.Collections.Generic;
using System.Linq;
using DependencyInjection.Autofac.MVC.Models;

namespace DependencyInjection.Autofac.MVC.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetById(int id)
        {
            List<Customer> customers = GetAll();
            return customers.FirstOrDefault(item => item.Id == id);
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>
            {
                    new Customer { Id = 1, Name = "Miguel A. Castro", Email = "miguel@dotnetdude.com", Twitter = "@miguelcastro67" },
                    new Customer { Id = 2, Name = "John V. Petersen", Email = "johnvpetersen@gmail.com", Twitter = "@johnvpetersen" },
                };

            return customers;
        }

        public void Update(Customer customer)
        {
        }
    }
}
