using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(4)]
        public string Description { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public AppUser Commenter { get; set; }

        [Required]
        public Ride Ride { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }
    }
}