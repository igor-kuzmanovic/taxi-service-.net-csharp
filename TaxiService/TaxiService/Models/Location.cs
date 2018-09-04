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
            Longitude = form.Longitude;
            Latitude = form.Latitude;
            Street = form.Street;
            StreetNumber = form.StreetNumber;
            City = form.City;
            PostalCode = form.PostalCode;
        }

        public Location(RideCreateForm form)
        {
            Longitude = form.Longitude;
            Latitude = form.Latitude;
            Street = form.Street;
            StreetNumber = form.StreetNumber;
            City = form.City;
            PostalCode = form.PostalCode;
        }

        public Location(RideSuccessForm form)
        {
            Longitude = form.Longitude;
            Latitude = form.Latitude;
            Street = form.Street;
            StreetNumber = form.StreetNumber;
            City = form.City;
            PostalCode = form.PostalCode;
        }

        [Key]
        public int Id { get; set; }

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

        public override string ToString()
        {
            return $"{Street} {StreetNumber} - {City} {PostalCode} ({Longitude}, {Latitude})";
        }
    }
}