using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using DependencyInjection.MEF.MVC.Models;
using DependencyInjection.MEF.MVC.Services;

namespace DependencyInjection.MEF.MVC.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        readonly ICustomerRepository _CustomerRepository;

        [ImportingConstructor]
        public HomeController(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
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