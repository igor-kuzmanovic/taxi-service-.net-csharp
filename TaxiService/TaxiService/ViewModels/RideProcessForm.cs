using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class RideProcessForm
    {
        public RideProcessForm() { }

        public RideProcessForm(Ride ride)
        {
            Id = ride.Id;
            OrderDateTime = ride.OrderDateTime;
            Longitude = ride.Source.Longitude;
            Latitude = ride.Source.Latitude;
            Street = ride.Source.Street;
            StreetNumber = ride.Source.StreetNumber;
            City = ride.Source.City;
            PostalCode = ride.Source.PostalCode;
            VehicleType = ride.VehicleType;
            FirstName = ride.Dispatcher.FirstName;
            LastName = ride.Dispatcher.LastName;
        }

        public int Id { get; set; }

        [Display(Name = "Order Date Time")]
        public DateTime OrderDateTime { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Street { get; set; }

        [Display(Name = "Street Number")]
        public int StreetNumber { get; set; }

        public string City { get; set; }

        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        [EnumDataType(typeof(RideVehicleType))]
        [Display(Name = "Vehicle Type")]
        public RideVehicleType VehicleType { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}