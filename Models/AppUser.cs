using Microsoft.AspNetCore.Identity;

namespace Pronia.Models;

public class AppUser : IdentityUser
{
    public String LastName { get; set; }

    public String FirstName { get; set; }
}
