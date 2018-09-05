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
            context.AppUsers.AddOrUpdate(new AppUser()
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                FirstName = "Adam",
                LastName = "Adminton",
                Gender = Gender.Male,
                UMCN = "1231231231231",
                Phone = "065 656 656",
                Email = "admin@taxiservice.com",
                Role = UserRole.Dispatcher
            });

            context.SaveChanges();

            context.AppUsers.AddOrUpdate(new AppUser()
            {
                Id = 2,
                Username = "driver1",
                Password = "driver1",
                FirstName = "Anne",
                LastName = "Driverson",
                Gender = Gender.Female,
                UMCN = "2342342342342",
                Phone = "061 616 616",
                Email = "anne@email.com",
                Role = UserRole.Driver,
                IsDriverBusy = true,
                Location = new Location()
                {
                    Id = 1,
                    Longitude = 1,
                    Latitude = 1,
                    Street = "Main Street",
                    StreetNumber = 15,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                Vehicle = null
            });

            context.SaveChanges();

            context.Vehicles.AddOrUpdate(new Vehicle()
            {
                Id = 1,
                Driver = context.AppUsers.Find(2),
                Year = 2007,
                Registration = "NS-5R5-5A5",
                Type = VehicleType.Car
            });

            context.SaveChanges();

            context.AppUsers.AddOrUpdate(new AppUser()
            {
                Id = 3,
                Username = "driver2",
                Password = "driver2",
                FirstName = "John",
                LastName = "Driverson",
                Gender = Gender.Male,
                UMCN = "3453453453453",
                Phone = "062 252 252",
                Email = "john@email.com",
                Role = UserRole.Driver,
                IsDriverBusy = true,
                Location = new Location()
                {
                    Id = 2,
                    Longitude = 2,
                    Latitude = 2,
                    Street = "Side Street",
                    StreetNumber = 13,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                Vehicle = null
            });

            context.SaveChanges();

            context.Vehicles.AddOrUpdate(new Vehicle()
            {
                Id = 2,
                Driver = context.AppUsers.Find(3),
                Year = 2011,
                Registration = "NS-A5R-2RT",
                Type = VehicleType.Van
            });

            context.SaveChanges();

            context.Rides.AddOrUpdate(new Ride()
            {
                Id = 1,
                OrderDateTime = new DateTime(2018, 9, 5, 17, 35, 15),
                Source = new Location()
                {
                    Id = 3,
                    Longitude = 3,
                    Latitude = 3,
                    Street = "Red Street",
                    StreetNumber = 11,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                VehicleType = RideVehicleType.Any,
                Destination = null,
                Dispatcher = context.AppUsers.Find(1),
                Driver = context.AppUsers.Find(2),
                Price = null,
                Comment = null,
                Status = RideStatus.Formed
            });

            context.SaveChanges();

            context.Rides.AddOrUpdate(new Ride()
            {
                Id = 2,
                OrderDateTime = new DateTime(2018, 9, 5, 9, 11, 35),
                Source = new Location()
                {
                    Id = 4,
                    Longitude = 4,
                    Latitude = 4,
                    Street = "Dove Street",
                    StreetNumber = 51,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                VehicleType = RideVehicleType.Any,
                Destination = null,
                Dispatcher = context.AppUsers.Find(1),
                Driver = context.AppUsers.Find(3),
                Price = null,
                Comment = null,
                Status = RideStatus.Formed
            });

            context.SaveChanges();

            context.Rides.AddOrUpdate(new Ride()
            {
                Id = 3,
                OrderDateTime = new DateTime(2018, 1, 2, 13, 51, 34),
                Source = new Location()
                {
                    Id = 5,
                    Longitude = 5,
                    Latitude = 5,
                    Street = "Whale Street",
                    StreetNumber = 11,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                VehicleType = RideVehicleType.Car,
                Destination = new Location()
                {
                    Id = 6,
                    Longitude = 6,
                    Latitude = 6,
                    Street = "Groove Street",
                    StreetNumber = 12,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                Dispatcher = context.AppUsers.Find(1),
                Driver = context.AppUsers.Find(2),
                Price = 350,
                Comment = null,
                Status = RideStatus.Successful
            });

            context.SaveChanges();

            context.Rides.AddOrUpdate(new Ride()
            {
                Id = 4,
                OrderDateTime = new DateTime(2017, 11, 12, 15, 56, 12),
                Source = new Location()
                {
                    Id = 7,
                    Longitude = 7,
                    Latitude = 7,
                    Street = "Green Street",
                    StreetNumber = 11,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                VehicleType = RideVehicleType.Any,
                Destination = new Location()
                {
                    Id = 8,
                    Longitude = 8,
                    Latitude = 8,
                    Street = "Purple Street",
                    StreetNumber = 34,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                Dispatcher = context.AppUsers.Find(1),
                Driver = context.AppUsers.Find(3),
                Price = 235,
                Comment = null,
                Status = RideStatus.Successful
            });

            context.SaveChanges();

            context.Rides.AddOrUpdate(new Ride()
            {
                Id = 5,
                OrderDateTime = new DateTime(2017, 10, 23, 22, 15, 34),
                Source = new Location()
                {
                    Id = 9,
                    Longitude = 9,
                    Latitude = 9,
                    Street = "Yellow Street",
                    StreetNumber = 45,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                VehicleType = RideVehicleType.Van,
                Destination = null,
                Dispatcher = context.AppUsers.Find(1),
                Driver = context.AppUsers.Find(3),
                Price = null,
                Comment = null,
                Status = RideStatus.Failed
            });

            context.SaveChanges();

            context.Comments.AddOrUpdate(new Comment()
            {
                Id = 1,
                Description = "Car broke down",
                CreationDate = new DateTime(2017, 10, 23, 22, 27, 13),
                Commenter = context.AppUsers.Find(3),
                Ride = context.Rides.Find(5),
                Rating = Rating.Three
            });

            context.SaveChanges();

            context.Rides.AddOrUpdate(new Ride()
            {
                Id = 6,
                OrderDateTime = new DateTime(2016, 11, 25, 11, 16, 56),
                Source = new Location()
                {
                    Id = 10,
                    Longitude = 10,
                    Latitude = 10,
                    Street = "Green Street",
                    StreetNumber = 2,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                VehicleType = RideVehicleType.Any,
                Destination = null,
                Dispatcher = context.AppUsers.Find(1),
                Driver = context.AppUsers.Find(2),
                Price = null,
                Comment = null,
                Status = RideStatus.Failed
            });

            context.SaveChanges();

            context.Comments.AddOrUpdate(new Comment()
            {
                Id = 2,
                Description = "Customer was acting inappropriately",
                CreationDate = new DateTime(2016, 11, 25, 11, 34, 12),
                Commenter = context.AppUsers.Find(2),
                Ride = context.Rides.Find(6),
                Rating = Rating.One
            });

            context.SaveChanges();
        }
    }
}