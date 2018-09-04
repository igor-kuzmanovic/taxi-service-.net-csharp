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
            Driver = driver;
            Year = form.Year;
            Registration = form.Registration;
            Identification = form.Identification;
            Type = form.Type;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public AppUser Driver { get; set; }

        [Required]
        [Range(1900, 2018)]
        public int Year { get; set; }

        [Required]
        [StringLength(100)]
        public string Registration { get; set; }

        [Key]
        [Range(100, 999)]
        public int Identification { get; set; }

        [Required]
        [EnumDataType(typeof(VehicleType))]
        public VehicleType Type { get; set; }

        public void Update(VehicleEditForm form)
        {
            Year = form.Year;
            Registration = form.Registration;
            Identification = form.Identification;
            Type = form.Type;
        }
    }
}