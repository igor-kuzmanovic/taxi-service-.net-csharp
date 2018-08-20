using System;
using System.Collections.Generic;
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
        Customer,
        Dispatcher
    }

    public enum VehicleType
    {
        Unknown,
        Car,
        Van
    }

    public enum RideStatus
    {
        Created,
        Formed,
        Processed,
        Accepted,
        Cancelled,
        Failed,
        Successful
    }
}