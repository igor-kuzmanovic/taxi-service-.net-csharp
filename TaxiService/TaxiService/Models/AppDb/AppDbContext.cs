using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}