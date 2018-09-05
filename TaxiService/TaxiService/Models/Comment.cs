using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TaxiService.ViewModels;

namespace TaxiService.Models
{
    public class Comment
    {
        public Comment() { }

        public Comment(RideFailForm form, AppUser commenter, Ride ride)
        {
            Description = form.Description;
            CreationDate = DateTime.Now;
            Commenter = commenter;
            Ride = ride;
            Rating = form.Rating;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public AppUser Commenter { get; set; }

        [Required]
        public Ride Ride { get; set; }

        public Rating Rating { get; set; }
    }
}