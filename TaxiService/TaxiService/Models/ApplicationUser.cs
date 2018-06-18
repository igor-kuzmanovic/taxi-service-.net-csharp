using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class ApplicationUser
    {
        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender? Gender { get; set; }

        public string UMCN { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public UserRole? Role { get; set; }

        public ICollection<int> RideIds { get; set; }
    }
}