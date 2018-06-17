using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public Customer Customer { get; set; }

        public Ride Ride { get; set; }

        public int Rating { get; set; }
    }
}