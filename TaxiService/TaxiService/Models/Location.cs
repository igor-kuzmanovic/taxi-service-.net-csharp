using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(-180, 180)]
        public int Longitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public int Latitude { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(4)]
        public string Street { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(4)]
        public string City { get; set; }

        [Required]
        public int PostalCode { get; set; }
    }
}