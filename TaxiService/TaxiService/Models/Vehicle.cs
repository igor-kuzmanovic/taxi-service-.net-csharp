using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            Driver = driver;
            Year = form.Year;
            Registration = form.Registration;
            Type = form.Type;
        }

        public int Id { get; set; }

        [Required]
        public AppUser Driver { get; set; }

        public int Year { get; set; }

        public string Registration { get; set; }

        public VehicleType Type { get; set; }

        public void Update(VehicleEditForm form)
        {
            Year = form.Year;
            Registration = form.Registration;
            Type = form.Type;
        }
    }
}