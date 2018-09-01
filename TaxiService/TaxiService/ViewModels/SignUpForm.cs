using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.ViewModels
{
    public class SignUpForm
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(3)]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}