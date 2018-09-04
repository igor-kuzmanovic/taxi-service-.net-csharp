using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum UserRole
    {
        Driver,
        Dispatcher
    }

    public enum VehicleType
    {
        Car,
        Van
    }

    public enum RideVehicleType
    {
        Any,
        Car,
        Van
    }

    public enum RideStatus
    {
        Formed,
        Failed,
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
        Any,
        Formed,
        Failed,
        Successful
    }

    public enum SortBy
    {
        None,
        [Display(Name = "Order Date")]
        OrderDate,
        Rating
    }
}