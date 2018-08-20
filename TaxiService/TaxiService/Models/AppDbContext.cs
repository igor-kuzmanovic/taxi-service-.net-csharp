using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<AppUser> AppUsers;
        public DbSet<Ride> Rides;
        public DbSet<Location> Locations;
        public DbSet<Vehicle> Vehicles;
        public DbSet<Comment> Comments;
    }
}