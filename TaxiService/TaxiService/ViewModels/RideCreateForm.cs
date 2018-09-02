using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class RideCreateForm
    {
        [Required]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StreetNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [Range(10000, 50000)]
        public int PostalCode { get; set; }

        [Required]
        [EnumDataType(typeof(VehicleType))]
        public VehicleType VehicleType { get; set; }

        [Required]
        public int DriverId { get; set; }
    }
}