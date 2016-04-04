using System.Collections.Generic;
using System.Web.Mvc;
using DependencyInjection.Autofac.MVC.Models;
using DependencyInjection.Autofac.MVC.Services;

namespace DependencyInjection.Autofac.MVC.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository _customerRepository;

        public HomeController(ICustomerRepository customerRepository)
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Customers()
        {
            IEnumerable<Customer> customers = _customerRepository.GetAll();
            return View(customers);
        }

        public ActionResult Customer(int id)
        {
            Customer customer = _customerRepository.GetById(id);
            return View(customer);
        }
    }
}