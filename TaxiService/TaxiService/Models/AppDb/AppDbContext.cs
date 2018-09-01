using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public DbSet<AppUser> AppUsers { get; set; }

        //public DbSet<Ride> Rides { get; set; }
        //public DbSet<Location> Locations { get; set; }
        //public DbSet<Vehicle> Vehicles { get; set; }
        //public DbSet<Comment> Comments { get; set; }
    }
}