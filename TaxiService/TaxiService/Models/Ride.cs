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

        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDateTime { get; set; }

        [Required]
        public Location Source { get; set; }

        [Required]
        [EnumDataType(typeof(RideVehicleType))]
        public RideVehicleType VehicleType { get; set; }

        public Location Destination { get; set; }

        [Required]
        public AppUser Dispatcher { get; set; }

        [Required]
        public AppUser Driver { get; set; }

        public int? Price { get; set; }

        public Comment Comment { get; set; }

        [Required]
        [EnumDataType(typeof(RideStatus))]
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