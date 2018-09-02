using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TaxiService.ViewModels;

namespace TaxiService.Models
{
    public class AppUser
    {
        public AppUser()
        {
            Rides = new HashSet<Ride>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsLoggedIn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender? Gender { get; set; }

        public string UMCN { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public UserRole? UserRole { get; set; }

        public ICollection<Ride> Rides { get; set; }

        public Location Location { get; set; }

        public Vehicle Vehicle { get; set; }

        public void UpdateProfile(ProfileEditForm form)
        {
            form = form ?? new ProfileEditForm();
            Password = form.Password;
            FirstName = form.FirstName;
            LastName = form.LastName;
            Gender = form.Gender;
            UMCN = form.UMCN;
            Phone = form.Phone;
            Email = form.Email;
        }

        public void UpdateLocation(Location location)
        {
            location = location ?? new Location();
            Location = location;
        }
    }
}