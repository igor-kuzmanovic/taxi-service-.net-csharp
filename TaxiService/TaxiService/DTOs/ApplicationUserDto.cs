using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.DTOs
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}