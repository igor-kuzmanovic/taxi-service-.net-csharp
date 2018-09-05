using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaxiService.ViewModels;

namespace TaxiService.Models
{
    public class Ride
    {
        public Ride() { }

        public Ride(Location source, AppUser dispatcher, RideVehicleType vehicleType, AppUser driver)
        {
            OrderDateTime = DateTime.Now;
            Source = source;
            VehicleType = vehicleType;
            Dispatcher = dispatcher;
            Driver = driver;
            Status = RideStatus.Formed;
        }

        public int Id { get; set; }

        public DateTime OrderDateTime { get; set; }

        public Location Source { get; set; }

        public RideVehicleType VehicleType { get; set; }

        public Location Destination { get; set; }

        public AppUser Dispatcher { get; set; }

        public AppUser Driver { get; set; }

        public int? Price { get; set; }

        public Comment Comment { get; set; }

        public RideStatus Status { get; set; }

        public void Update(RideSuccessForm form)
        {
            Destination = new Location(form);
            Price = form.Price;
            Status = RideStatus.Successful;
        }

        public void Update(RideFailForm form)
        {
            Comment = new Comment(form, Driver, this);
            Status = RideStatus.Failed;
        }
    }
}