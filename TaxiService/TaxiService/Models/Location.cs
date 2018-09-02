using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaxiService.ViewModels;

namespace TaxiService.Models
{
    public class Location
    {
        public Location() { }

        public Location(LocationUpdateForm form)
        {
            form = form ?? new LocationUpdateForm();
            Longitude = form.Longitude;
            Latitude = form.Latitude;
            Street = form.Street;
            StreetNumber = form.StreetNumber;
            City = form.City;
            PostalCode = form.PostalCode;
        }

        public int Id { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public string Street { get; set; }

        public int? StreetNumber { get; set; }

        public string City { get; set; }

        public int? PostalCode { get; set; }
    }
}