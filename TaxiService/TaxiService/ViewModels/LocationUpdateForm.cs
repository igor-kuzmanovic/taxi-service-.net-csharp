using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class LocationUpdateForm
    {
        public LocationUpdateForm() { }

        public LocationUpdateForm(Location location)
        {
            location = location ?? new Location();
            Longitude = location.Longitude ?? 0;
            Latitude = location.Latitude ?? 0;
            Street = location.Street;
            StreetNumber = location.StreetNumber ?? 0;
            City = location.City;
            PostalCode = location.PostalCode ?? 0;
        }

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
        public int StreetNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [Range(5,5)]
        public int PostalCode { get; set; }
    }
}