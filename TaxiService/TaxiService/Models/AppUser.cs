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

        public void Update(ProfileEditForm profileEditForm)
        {
            Password = profileEditForm.Password;
            FirstName = profileEditForm.FirstName;
            LastName = profileEditForm.LastName;
            Gender = profileEditForm.Gender;
            UMCN = profileEditForm.UMCN;
            Phone = profileEditForm.Phone;
            Email = profileEditForm.Email;
        }
    }
}