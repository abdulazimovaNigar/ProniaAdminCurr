using Microsoft.AspNetCore.Identity;

namespace ProniaAdmin.Models
{
    public class AppUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        //public string EmailAddress { get; set; }
        //public string PasswordHash { get; set; }
        //public string PhoneNumber { get; set; }
        //public DateTime Birthdate { get; set; }
    }
}
