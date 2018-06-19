using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiService.DAL;
using TaxiService.DTOs;
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
        public IHttpActionResult Create(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isUsernameUnique = _context.Customers.Any(c => c.Username == customerDto.Username);

            if (isUsernameUnique)
            {
                return BadRequest("Username already exists");
            }

            var isEmailUnique = _context.Customers.Any(c => c.Email == customerDto.Email);


            if (isEmailUnique)
            {
                return BadRequest("Email already exists");
            }

            var customer = new Customer
            {
                Username = customerDto.Username,
                Password = customerDto.Password,
                Email = customerDto.Email
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created("", customerDto);
        }
    }
}
