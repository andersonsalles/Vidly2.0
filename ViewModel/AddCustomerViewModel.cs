using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class AddCustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}