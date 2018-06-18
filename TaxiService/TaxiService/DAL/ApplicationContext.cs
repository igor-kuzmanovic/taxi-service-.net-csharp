using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaxiService.Models;

namespace TaxiService.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ApplicationContext") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dispatcher> Dispatchers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Ride> Rides { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
    }
}