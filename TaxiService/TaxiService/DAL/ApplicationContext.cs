using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaxiService.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ApplicationContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
    }
}