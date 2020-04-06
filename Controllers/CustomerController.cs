using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var custumers = new List<Customer>()
            {
                new Customer {Name = "Customer 1", Id = 1},
                new Customer {Name = "Customer 2", Id = 2}

            };
            var viewModel = new CustomerViewModel
            {
                Custumer = custumers
            };
            return View(viewModel);
        }

        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            var customer = new Customer
            {
                Name = id == 1 ? "Customer 1" : "Customer 2", Id = id
            };


            return View(customer);
        }
    }
}