using System.ComponentModel.DataAnnotations;

namespace practice.Application.Common.Dto_s;

public class RegisterDto
{
    public string Fullname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
