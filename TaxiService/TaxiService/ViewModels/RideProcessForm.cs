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
            OrderDateTime = ride.OrderDateTime ?? DateTime.Now;
            Longitude = ride.Source.Longitude ?? 0;
            Latitude = ride.Source.Latitude ?? 0;
            Street = ride.Source.Street;
            StreetNumber = ride.Source.StreetNumber ?? 0;
            City = ride.Source.City;
            PostalCode = ride.Source.PostalCode ?? 0;
            VehicleType = ride.VehicleType ?? RideVehicleType.Any;
            FirstName = ride.Dispatcher.FirstName;
            LastName = ride.Dispatcher.LastName;
        }

        public int Id { get; set; }

        public DateTime OrderDateTime { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public string City { get; set; }

        public int PostalCode { get; set; }

        [EnumDataType(typeof(RideVehicleType))]
        public RideVehicleType VehicleType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}