using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaxiService.ViewModels;

namespace TaxiService.Models
{
    public class Vehicle
    {
        public Vehicle() { }

        public Vehicle(AppUser driver, VehicleEditForm form)
        {
            driver = driver ?? new AppUser();
            form = form ?? new VehicleEditForm();
            Driver = driver;
            Year = form.Year;
            Registration = form.Registration;
            Identification = form.Identification;
            Type = form.Type;
        }

        public int Id { get; set; }

        [Required]
        public AppUser Driver { get; set; }

        public int? Year { get; set; }

        public string Registration { get; set; }

        public int? Identification { get; set; }

        public VehicleType? Type { get; set; }

        public void Update(VehicleEditForm form)
        {
            form = form ?? new VehicleEditForm();
            Year = form.Year;
            Registration = form.Registration;
            Identification = form.Identification;
            Type = form.Type;
        }
    }
}