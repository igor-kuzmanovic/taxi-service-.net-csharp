using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Car
    {
        public int Id { get; set; }

        public Driver Driver { get; set; }

        public int Year { get; set; }

        public string Registration { get; set; }

        public int Identification { get; set; }

        public CarType CarType { get; set; }
    }
}