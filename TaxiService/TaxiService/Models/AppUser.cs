using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string UMCN { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public UserRole UserRole { get; set; }
        public ICollection<string> Rides { get; set; }
        public Location Location { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}