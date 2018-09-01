using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public AppUser Driver { get; set; }

        public int? Year { get; set; }

        public string Registration { get; set; }

        public int? Identification { get; set; }

        public VehicleType? Type { get; set; }
    }
}