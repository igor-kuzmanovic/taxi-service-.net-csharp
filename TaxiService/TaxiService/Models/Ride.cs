using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Ride
    {
        public int RideId { get; set; }

        public DateTime CreationDateTime { get; set; }

        public int SourceId { get; set; }

        public CarType CarType { get; set; }

        public int CustomerId { get; set; }

        public int DestinationId { get; set; }

        public int DispatcherId { get; set; }

        public int DriverId { get; set; }

        public int Price { get; set; }

        public int CommentId { get; set; }
    }
}