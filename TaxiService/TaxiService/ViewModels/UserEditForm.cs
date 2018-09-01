using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class UserEditForm
    {
        public UserEditForm(AppUser appUser)
        {
            Id = appUser.Id;
            Password = appUser.Password;
            FirstName = appUser.FirstName;
            LastName = appUser.LastName;
            Gender = appUser.Gender;
            UMCN = appUser.UMCN;
            Phone = appUser.Phone;
            Email = appUser.Email;
        }

        public int Id { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender? Gender { get; set; }

        public string UMCN { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}