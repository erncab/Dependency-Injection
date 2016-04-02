using System.Collections.Generic;
using System.Web.Mvc;
using DependencyInjection.Autofac.MVC.Models;
using DependencyInjection.Autofac.MVC.Services;

namespace DependencyInjection.Autofac.MVC.Controllers
{
    public class HomeController : Controller
    {
        ICustomerRepository _CustomerRepository;

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
            IEnumerable<Customer> customers = _CustomerRepository.GetAll();
            return View(customers);
        }

        public ActionResult Customer(int id)
        {
            Customer customer = _CustomerRepository.GetById(id);
            return View(customer);
        }
    }
}