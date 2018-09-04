using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
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

        public AppUser(DriverCreateForm form)
        {
            Username = form.Username;
            Password = form.Password;
            FirstName = form.FirstName;
            LastName = form.LastName;
            Gender = form.Gender;
            UMCN = form.UMCN;
            Phone = form.Phone;
            Email = form.Email;
            Role = UserRole.Driver;
            IsDriverBusy = false;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender? Gender { get; set; }

        public string UMCN { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public UserRole? Role { get; set; }

        public bool? IsDriverBusy { get; set; }

        public virtual ICollection<Ride> Rides { get; set; }

        public virtual Location Location { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public void GetSignedInUserData(AppUser appUser)
        {
            Id = appUser.Id;
            Username = appUser.Username;
            FirstName = appUser.FirstName;
            LastName = appUser.LastName;
            Role = appUser.Role;
            IsDriverBusy = appUser.IsDriverBusy;
        }

        public void UpdateProfile(ProfileEditForm form)
        {
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
            Location = location;
        }
    }
}