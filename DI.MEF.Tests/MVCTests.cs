using System.Collections.Generic;
using System.Web.Mvc;
using DependencyInjection.MEF.MVC.Controllers;
using DependencyInjection.MEF.MVC.Models;
using DependencyInjection.MEF.MVC.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DI.MEF.Tests
{
    [TestClass]
    public class MVCTests
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

        [TestMethod]
        public void test_customers_action_for_correct_view()
        {
            HomeController controller = new HomeController(new TestCustomerRepository());
            ActionResult result = controller.Customers();
            ViewResult viewResult = result as ViewResult;

            Assert.IsTrue(viewResult != null);
            Assert.IsTrue(viewResult.Model is IEnumerable<Customer>);
        }
    }
}
