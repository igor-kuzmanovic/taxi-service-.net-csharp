using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiService.Models
{
    public enum UserRole
    {
        Unknown,
        Customer,
        Driver,
        Dispatcher
    }

    public enum Gender
    {
        Unknown,
        Male,
        Female
    }

    public enum CarType
    {
        Unknown,
        Passenger,
        Van
    }

    public enum RideState
    {
        Unknown,
        InWaiting,
        Created,
        Processed,
        Accepted,
        Cancelled,
        InProgress,
        Unsuccessful,
        Successful
    }
}