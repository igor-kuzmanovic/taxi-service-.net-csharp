using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class RideFailForm
    {
        public RideFailForm() { }

        public RideFailForm(int rideId)
        {
            RideId = rideId;
        }

        [Required]
        [Display(Name = "Ride")]
        public int RideId { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(Rating))]
        public Rating Rating { get; set; }
    }
}