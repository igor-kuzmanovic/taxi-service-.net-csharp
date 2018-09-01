using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class ProfileEditForm
    {
        public ProfileEditForm() { }

        public ProfileEditForm(AppUser appUser)
        {
            Id = appUser.Id;
            Password = appUser.Password;
            FirstName = appUser.FirstName;
            LastName = appUser.LastName;
            Gender = appUser.Gender.HasValue ? appUser.Gender.Value : Gender.Male;
            UMCN = appUser.UMCN;
            Phone = appUser.Phone;
            Email = appUser.Email;
        }

        [Required]
        public int Id { get; set; }

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
        public Gender Gender { get; set; }

        [Required]
        [StringLength(13)]
        public string UMCN { get; set; }

        [Required]
        [Phone]
        [StringLength(100)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
    }
}