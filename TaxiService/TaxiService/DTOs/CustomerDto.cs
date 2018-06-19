using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiService.Models;

namespace TaxiService.DTOs
{
    public class CustomerDto : ApplicationUserDto
    {
        public UserRole Role { get; } = UserRole.Customer;
    }
}