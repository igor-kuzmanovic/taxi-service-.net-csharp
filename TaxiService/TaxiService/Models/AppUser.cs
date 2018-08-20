using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [MaxLength(255)]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        public string UMCN { get; set; }

        [Required]
        [Phone]
        [MaxLength(255)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public UserRole UserRole { get; set; }

        //public ICollection<Ride> Rides { get; set; }

        //public Location Location { get; set; }

        //public Vehicle Vehicle { get; set; }
    }
}