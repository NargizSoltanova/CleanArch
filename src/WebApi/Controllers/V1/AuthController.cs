using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using practice.Application.Common.Dto_s;
using practice.Domain.Identity;
using RabbitMQ.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace practice.WebApi.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<AppUser> userManager, IConfiguration configuration, RoleManager<AppRole> roleManager, IWebHostEnvironment environment)
    {
        _userManager = userManager;
        _configuration = configuration;
        _roleManager = roleManager;
        _environment = environment;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var user = new AppUser()
        {
            Fullname = registerDto.Fullname,
            Email = registerDto.Email,
            UserName = registerDto.Username
        };
        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            return BadRequest(new
            {
                Title = result.Errors.Select(x => x.Code),
                Description = result.Errors.Select(x => x.Description)
            });
        }

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var url = Url.Action("ConfirmEmail", "Auth", new { userId = user.Id, token = token }, Request.Scheme);

        ConnectionFactory factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://qwmnpfdy:Lkfkc8vt-zaX8ao1deKwpzxAeGE5eKxN@rat.rmq2.cloudamqp.com/qwmnpfdy");
        using (IConnection connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("message-queue", false, false, true);
                Tuple<string, string, string> dict = new Tuple<string, string, string>(user.Email, $"<a href={url}>Verify Email</a>", "Confirm Email");
                var body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(dict));
                channel.BasicPublish("", "message-queue", basicProperties: null, body: body);
            }
        }
        //var result2 = await _userManager.AddToRoleAsync(user, "member");
        //if (!result2.Succeeded)  4242475
        //{
        //    return BadRequest(new
        //    {
        //        Title = result2.Errors.Select(x => x.Code),
        //        Description = result2.Errors.Select(x => x.Description)
        //    });
        //}
        return Ok("Register Success.Please,confirm your email");
    }
    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();
        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            return Ok("Email Confirmed");
        }
        return BadRequest();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.Username);
        if (user == null) return Unauthorized();
        if (!user.EmailConfirmed) return BadRequest("Confirm your email");
        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result) return Unauthorized();

        double date = double.Parse(_configuration["JWT:expireDate"]);
        DateTime expires = DateTime.UtcNow.AddMinutes(date);

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim("Fullname",user.Fullname),
            new Claim(ClaimTypes.Email, user.Email)
        };

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:securityKey"]));
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken securityToken = new JwtSecurityToken(
            issuer: _configuration["JWT:issuer"],
            audience: _configuration["JWT:audience"],
            expires: expires,
            claims: claims,
            signingCredentials: signingCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return Ok(new
        {
            token = token,
            expierDate = expires
        });
    }
    [HttpPost("CreateRoles")]
    public async Task<IActionResult> CreateRoles()
    {
        await _roleManager.CreateAsync(new AppRole { Name = "Member" });
        await _roleManager.CreateAsync(new AppRole { Name = "Admin" });
        return Ok("Created");
    }
}
