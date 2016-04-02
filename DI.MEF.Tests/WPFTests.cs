using System.Collections.Generic;
using DI.MEF.WPF.Services;
using DI.MEF.WPF.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DI.MEF.Tests
{
    public class TestCustomerRepository : ICustomerRepository
    {
        Customer ICustomerRepository.GetById(int id)
        {
            return new Customer();
        }

        List<Customer> ICustomerRepository.GetAll()
            {
                return new List<Customer>() { new Customer() };
            }

        void ICustomerRepository.Update(Customer customer)
        {
        }
    }

    [TestClass]
    public class WPFTests
    {
        [TestMethod]
        public void test_customer_list_view_model_for_something()
        {
            CustomerListViewModel viewModel = new CustomerListViewModel(new TestCustomerRepository());

            // assert something
            Assert.IsTrue(1 == 1);
        }
    }
}
