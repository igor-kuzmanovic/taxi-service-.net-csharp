using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public int AddressId { get; set; }
    }
}