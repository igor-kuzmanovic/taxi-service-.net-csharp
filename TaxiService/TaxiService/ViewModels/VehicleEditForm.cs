using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class VehicleEditForm
    {
        public VehicleEditForm() { }

        public VehicleEditForm(Vehicle vehicle)
        {
            Id = vehicle.Id;
            Year = vehicle.Year ?? 0;
            Registration = vehicle.Registration;
            Identification = vehicle.Identification ?? 0;
            Type = vehicle.Type ?? VehicleType.Car;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Range(1900, 2018)]
        public int Year { get; set; }

        [Required]
        [StringLength(100)]
        public string Registration { get; set; }

        [Required]
        [Range(100, 999)]
        public int Identification { get; set; }

        [Required]
        [EnumDataType(typeof(VehicleType))]
        public VehicleType Type { get; set; }
    }
}