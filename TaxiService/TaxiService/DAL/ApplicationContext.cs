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

        DbSet<Customer> Customers { get; set; }
        DbSet<Dispatcher> Dispatchers { get; set; }
        DbSet<Driver> Drivers { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Ride> Rides { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
    }
}