using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public int CustomerId { get; set; }

        public int RideId { get; set; }

        public int Rating { get; set; }
    }
}