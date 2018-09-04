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
        [Display(Name = "Car")]
        Car,
        [Display(Name = "Van")]
        Van
    }

    public enum RideVehicleType
    {
        [Display(Name = "Any")]
        Any,
        [Display(Name = "Car")]
        Car,
        [Display(Name = "Van")]
        Van
    }

    public enum RideStatus
    {
        [Display(Name = "Formed")]
        Formed,
        [Display(Name = "Failed")]
        Failed,
        [Display(Name = "Successful")]
        Successful
    }

    public enum Rating
    {
        [Display(Name = "No Rating")]
        NoRating,
        [Display(Name = "*")]
        One = 1,
        [Display(Name = "**")]
        Two = 2,
        [Display(Name = "***")]
        Three = 3,
        [Display(Name = "****")]
        Four = 4,
        [Display(Name = "*****")]
        Five = 5
    }

    public enum RideStatusFilter
    {
        [Display(Name = "Any")]
        Any,
        [Display(Name = "Formed")]
        Formed,
        [Display(Name = "Failed")]
        Failed,
        [Display(Name = "Successful")]
        Successful
    }

    public enum SortBy
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Order Date")]
        OrderDate,
        [Display(Name = "Rating")]
        Rating
    }
}