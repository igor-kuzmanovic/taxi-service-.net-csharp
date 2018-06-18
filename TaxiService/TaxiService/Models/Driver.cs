using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Driver : ApplicationUser
    {
        public int DriverId { get; set; }

        public int LocationId { get; set; }

        public int CarId { get; set; }
    }
}