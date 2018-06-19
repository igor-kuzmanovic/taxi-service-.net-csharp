using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TaxiService.DAL;
using TaxiService.Models;

namespace TaxiService.Helpers
{
    public static class LoginHelper
    {
        public static void GetCredentials(string credentials, out string username, out string password)
        {
            username = string.Empty;
            password = string.Empty;

            if (string.IsNullOrWhiteSpace(credentials))
                return;

            byte[] data = Convert.FromBase64String(credentials);
            string decodedCredentials = Encoding.UTF8.GetString(data);

            if (!decodedCredentials.Contains(':'))
                return;

            string[] splitCredentials = decodedCredentials.Split(':');

            if (splitCredentials.Count() != 2)
                return;

            username = splitCredentials.First();
            password = splitCredentials.Last();
        }

        public static bool Authenticate(ApplicationContext context, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            return context.Customers.Any(c => c.Username == username && c.Password == password);            
        }

        public static bool Authorize(ApplicationContext context, string username, UserRole role)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            return context.Customers.Any(c => c.Username == username && c.Role == role);
        }
    }
}