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
        One,
        [Display(Name = "**")]
        Two,
        [Display(Name = "***")]
        Three,
        [Display(Name = "****")]
        Four,
        [Display(Name = "*****")]
        Five
    }
}