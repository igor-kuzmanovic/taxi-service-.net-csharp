using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Ride
    {
        public int Id { get; set; }

        public DateTime CreationDateTime { get; set; }

        public Location Location { get; set; }

        public CarType CarType { get; set; }

        public Customer Customer { get; set; }

        public Location Destination { get; set; }

        public Dispatcher Dispatcher { get; set; }

        public Driver Driver { get; set; }

        public int Price { get; set; }

        public Comment Comment { get; set; }
    }
}