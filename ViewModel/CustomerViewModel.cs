using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using WebApplication1.Models;

namespace Vidly.ViewModel
{
    public class CustomerViewModel
    {
        public List<Customer> Custumer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}