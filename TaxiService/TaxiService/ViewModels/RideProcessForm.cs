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
            ride = ride ?? new Ride();
            Id = ride.Id;
            OrderDateTime = ride.OrderDateTime ?? DateTime.Now;
            OrderLocationLongitude = ride.OrderLocation.Longitude ?? 0;
            OrderLocationLatitude = ride.OrderLocation.Latitude ?? 0;
            OrderLocationStreet = ride.OrderLocation.Street;
            OrderLocationStreetNumber = ride.OrderLocation.StreetNumber ?? 0;
            OrderLocationCity = ride.OrderLocation.City;
            OrderLocationPostalCode = ride.OrderLocation.PostalCode ?? 0;
            VehicleType = ride.VehicleType ?? RideVehicleType.Any;
            DispatcherFirstName = ride.Dispatcher.FirstName;
            DispatcherLastName = ride.Dispatcher.LastName;
        }

        public int Id { get; set; }

        public DateTime OrderDateTime { get; set; }

        public double OrderLocationLongitude { get; set; }

        public double OrderLocationLatitude { get; set; }

        public string OrderLocationStreet { get; set; }

        public int OrderLocationStreetNumber { get; set; }

        public string OrderLocationCity { get; set; }

        public int OrderLocationPostalCode { get; set; }

        [EnumDataType(typeof(RideVehicleType))]
        public RideVehicleType VehicleType { get; set; }

        public string DispatcherFirstName { get; set; }

        public string DispatcherLastName { get; set; }
    }
}