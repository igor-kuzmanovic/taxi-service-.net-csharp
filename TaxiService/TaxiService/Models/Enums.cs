using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female
    }

    public enum UserRole
    {
        [Display(Name = "Driver")]
        Driver,
        [Display(Name = "Dispatcher")]
        Dispatcher
    }

    public enum VehicleType
    {
        [Display(Name = "Unknown")]
        Unknown,
        [Display(Name = "Car")]
        Car,
        [Display(Name = "Van")]
        Van
    }

    public enum RideStatus
    {
        [Display(Name = "Created")]
        Created,
        [Display(Name = "Formed")]
        Formed,
        [Display(Name = "Processed")]
        Processed,
        [Display(Name = "Accepted")]
        Accepted,
        [Display(Name = "Cancelled")]
        Cancelled,
        [Display(Name = "Failed")]
        Failed,
        [Display(Name = "Successful")]
        Successful
    }
}