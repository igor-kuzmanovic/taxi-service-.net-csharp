namespace TaxiService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        DriverId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Registration = c.String(),
                        Identification = c.Int(nullable: false),
                        CarType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        RideId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        UMCN = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Dispatchers",
                c => new
                    {
                        DispatcherId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        UMCN = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DispatcherId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        UMCN = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Rides",
                c => new
                    {
                        RideId = c.Int(nullable: false, identity: true),
                        CreationDateTime = c.DateTime(nullable: false),
                        SourceId = c.Int(nullable: false),
                        CarType = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DestinationId = c.Int(nullable: false),
                        DispatcherId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RideId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rides");
            DropTable("dbo.Locations");
            DropTable("dbo.Drivers");
            DropTable("dbo.Dispatchers");
            DropTable("dbo.Customers");
            DropTable("dbo.Comments");
            DropTable("dbo.Cars");
            DropTable("dbo.Addresses");
        }
    }
}
