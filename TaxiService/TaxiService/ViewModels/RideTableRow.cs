using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Status = ride.Status.ToString();
            OrderDateTime = ride.OrderDateTime.ToString();
            Dispatcher = $"{ride.Dispatcher.FirstName} {ride.Dispatcher.LastName}";
            Driver = $"{ride.Driver.FirstName} {ride.Driver.LastName}";
            Source = ride.Source.ToString();
            Destination = ride.Status == RideStatus.Successful ? ride.Destination.ToString() : "No Destination";
            Price = ride.Status == RideStatus.Successful ? ride.Price.ToString() : "No Price";
            Rating = ride.Status == RideStatus.Failed ? ride.Comment.Rating.ToString() : "No Rating";
            Comment = ride.Status == RideStatus.Failed ? $"[{ride.Comment.CreationDate}] {ride.Comment.Commenter.Username}: {ride.Comment.Description}" : "No Comment";
        }

        public string Status { get; set; }

        [Display(Name = "Order Date Time")]
        public string OrderDateTime { get; set; }

        public string Dispatcher { get; set; }

        public string Driver { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public string Price { get; set; }

        public string Rating { get; set; }

        public string Comment { get; set; }
    }
}