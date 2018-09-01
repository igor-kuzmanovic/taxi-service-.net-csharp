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
    }
}
