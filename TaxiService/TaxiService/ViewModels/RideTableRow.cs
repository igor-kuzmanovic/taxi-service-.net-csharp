using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class RideTableRow
    {
        public RideTableRow() { }

        public RideTableRow(Ride ride)
        {
            Id = ride.Id;
            Status = ride.Status.ToString();
            OrderDateTime = ride.OrderDateTime.ToString();
            Dispatcher = ride.Dispatcher.Username;
            Driver = ride.Driver.Username;
            Source = ride.Source.ToString();
            Destination = ride.Status == RideStatus.Successful ? ride.Destination.ToString() : "";
            Price = ride.Status == RideStatus.Successful ? Price = ride.Price : Price = null;
            Comment = ride.Status == RideStatus.Failed ? $"[{ride.Comment.CreationDate}] {(ride.Comment.Rating > 0 ? $"({(int)ride.Comment.Rating}/5)" : "No Rating")} {ride.Comment.Commenter.Username}: {ride.Comment.Description}" : string.Empty;
        }

        public int Id { get; set; }

        public string Status { get; set; }

        public string OrderDateTime { get; set; }

        public string Dispatcher { get; set; }

        public string Driver { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public int? Price { get; set; }

        public string Comment { get; set; }
    }
}