using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TaxiService.Models;

namespace TaxiService.Models
{
    internal sealed class AppDbConfiguration : DbMigrationsConfiguration<AppDbContext>
    {
        public AppDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
