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

        [Key]
        public int Id { get; set; }

        [Key]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string UMCN { get; set; }

        [Required]
        [Phone]
        [StringLength(100)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; }

        public bool? IsDriverBusy { get; set; }

        public virtual ICollection<Ride> Rides { get; set; }

        public virtual Location Location { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public void GetLoginData(AppUser appUser)
        {
            Id = appUser.Id;
            Username = appUser.Username;
            FirstName = appUser.FirstName;
            LastName = appUser.LastName;
            Role = appUser.Role;
            IsDriverBusy = appUser.IsDriverBusy;
        }

        public void Update(ProfileEditForm form)
        {
            Password = form.Password;
            FirstName = form.FirstName;
            LastName = form.LastName;
            Gender = form.Gender;
            UMCN = form.UMCN;
            Phone = form.Phone;
            Email = form.Email;
        }

        public void Update(Location location)
        {
            Location = location;
        }
    }
}