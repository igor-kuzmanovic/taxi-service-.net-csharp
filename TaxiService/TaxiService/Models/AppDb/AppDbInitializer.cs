using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            context.AppUsers.AddOrUpdate(new AppUser()
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                FirstName = "Adam",
                LastName = "Adminović",
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
                Username = "vozac1",
                Password = "vozac1",
                FirstName = "Ana",
                LastName = "Vozačević",
                Gender = Gender.Female,
                UMCN = "2342342342342",
                Phone = "061 616 616",
                Email = "ana@email.com",
                Role = UserRole.Driver,
                IsDriverBusy = true,
                Location = new Location()
                {
                    Id = 1,
                    Longitude = -125.21,
                    Latitude = 15.12,
                    Street = "Glavna Ulica",
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
                Username = "vozac2",
                Password = "vozac2",
                FirstName = "Stevan",
                LastName = "Vozačević",
                Gender = Gender.Male,
                UMCN = "3453453453453",
                Phone = "062 252 252",
                Email = "stevan@email.com",
                Role = UserRole.Driver,
                IsDriverBusy = true,
                Location = new Location()
                {
                    Id = 2,
                    Longitude = 112.32,
                    Latitude = 23.12,
                    Street = "Plava Ulica",
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
                    Longitude = 121.23,
                    Latitude = -4.58,
                    Street = "Crvena Ulica",
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
                    Longitude = -58.123,
                    Latitude = 44.23,
                    Street = "Srebrna Ulica",
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
                    Longitude = 3.12,
                    Latitude = -25.45,
                    Street = "Zlatni Bulevar",
                    StreetNumber = 11,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                VehicleType = RideVehicleType.Car,
                Destination = new Location()
                {
                    Id = 6,
                    Longitude = -123.23,
                    Latitude = 78.12,
                    Street = "Srebrni Bulevar",
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
                    Longitude = 77.12,
                    Latitude = -9.21,
                    Street = "Roze Ulica",
                    StreetNumber = 11,
                    City = "Novi Sad",
                    PostalCode = 21000
                },
                VehicleType = RideVehicleType.Any,
                Destination = new Location()
                {
                    Id = 8,
                    Longitude = -156.32,
                    Latitude = -78.12,
                    Street = "Trg Bronze",
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
                    Longitude = -112.43,
                    Latitude = 88.16,
                    Street = "Golubov Trg",
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
                Description = "Vozilo se pokvarilo na putu.",
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
                    Longitude = 78.213,
                    Latitude = -11.86,
                    Street = "Vojna Ulica",
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
                Description = "Mušterija je bila agresivna.",
                CreationDate = new DateTime(2016, 11, 25, 11, 34, 12),
                Commenter = context.AppUsers.Find(2),
                Ride = context.Rides.Find(6),
                Rating = Rating.One
            });

            context.SaveChanges();
        }
    }
}