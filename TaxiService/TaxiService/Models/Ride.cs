using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Ride
    {
        public int Id { get; set; }

        public DateTime? OrderDateTime { get; set; }

        public Location OrderLocation { get; set; }

        public VehicleType? VehicleType { get; set; }

        public Location Destination { get; set; }

        public AppUser Dispatcher { get; set; }

        public AppUser Driver { get; set; }

        public int? Price { get; set; }

        public Comment Comment { get; set; }

        public RideStatus? Status { get; set; }
    }
}