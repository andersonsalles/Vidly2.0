using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new AddCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }   

        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> custumers = GetCustomers(); 
                
          
            var viewModel = new CustomerViewModel
            {
                Custumer = custumers
            };
            return View(viewModel);
        }

        private List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
    }
}