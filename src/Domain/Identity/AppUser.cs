using Microsoft.AspNetCore.Identity;

namespace practice.Domain.Identity;

public class AppUser : IdentityUser
{
    public string Fullname { get; set; }
}
