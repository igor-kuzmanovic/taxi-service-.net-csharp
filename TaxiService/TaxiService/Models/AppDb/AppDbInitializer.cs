using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            context.AppUsers.AddOrUpdate(new AppUser() { Username = "admin", Password = "admin", Role = UserRole.Dispatcher });
            context.AppUsers.AddOrUpdate(new AppUser() { Username = "driver", Password = "driver", FirstName = "John", LastName = "Doe", Role = UserRole.Driver, IsDriverBusy = false, Vehicle = new Vehicle() });

            context.SaveChanges();
        }
    }
}