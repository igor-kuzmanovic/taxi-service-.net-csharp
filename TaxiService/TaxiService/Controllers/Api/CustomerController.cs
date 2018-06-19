using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiService.DAL;
using TaxiService.Models;

namespace TaxiService.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationContext _context;

        public CustomerController()
        {
            _context = new ApplicationContext();
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please check all fields");

            if (_context.Customers.Any(c => c.Username == customer.Username))
                return BadRequest("Username already exists");

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created("", customer);
        }
    }
}
