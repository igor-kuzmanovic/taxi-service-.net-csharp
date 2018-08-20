using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public AppUser Driver { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Registration { get; set; }

        [Required]
        public int Identification { get; set; }

        [Required]
        public VehicleType Type { get; set; }
    }
}