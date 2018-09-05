using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class RideSuccessForm
    {
        public RideSuccessForm() { }

        public RideSuccessForm(int rideId)
        {
            RideId = rideId;
        }

        [Required]
        [Display(Name = "Ride")]
        public int RideId { get; set; }

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
        [Range(1, int.MaxValue)]
        [Display(Name = "Street Number")]
        public int StreetNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [Range(10000, 50000)]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public int Price { get; set; }
    }
}