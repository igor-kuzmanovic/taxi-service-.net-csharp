using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime? CreationDate { get; set; }

        public AppUser Commenter { get; set; }

        public Ride Ride { get; set; }

        public int? Rating { get; set; }
    }
}