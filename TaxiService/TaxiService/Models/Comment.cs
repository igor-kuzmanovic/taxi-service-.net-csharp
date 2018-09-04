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

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [Required]
        public AppUser Commenter { get; set; }

        [Required]
        public Ride Ride { get; set; }

        [Required]
        [EnumDataType(typeof(Rating))]
        public Rating Rating { get; set; }
    }
}