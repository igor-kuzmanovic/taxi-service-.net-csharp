using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDateTime { get; set; }

        [Required]
        public Location OrderLocation { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        public AppUser Customer { get; set; }

        [Required]
        public Location Destination { get; set; }

        public AppUser Dispatcher { get; set; }

        [Required]
        public AppUser Driver { get; set; }

        [Required]
        public int Price { get; set; }

        public Comment Comment { get; set; }

        [Required]
        public RideStatus Status { get; set; }
    }
}