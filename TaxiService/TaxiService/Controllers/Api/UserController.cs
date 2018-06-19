using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiService.DAL;
using TaxiService.Helpers;

namespace TaxiService.Controllers.Api
{
    public class UserController : ApiController
    {
        private ApplicationContext _context;

        public UserController()
        {
            _context = new ApplicationContext();
        }

        [HttpPost]
        public IHttpActionResult LogIn()
        {
            string credentials = Request.Headers.Authorization.Parameter;

            if (string.IsNullOrWhiteSpace(credentials))
                return BadRequest();

            LoginHelper.GetCredentials(credentials, out string username, out string password);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return BadRequest();

            if (!LoginHelper.Authenticate(_context, username, password))
                return StatusCode(HttpStatusCode.Forbidden);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult LogOut()
        {
            string credentials = Request.Headers.Authorization.Parameter;

            if (string.IsNullOrWhiteSpace(credentials))
                return BadRequest();

            LoginHelper.GetCredentials(credentials, out string username, out string password);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return BadRequest();

            if (!LoginHelper.Authenticate(_context, username, password))
                return StatusCode(HttpStatusCode.Forbidden);

            return Ok();
        }
    }
}