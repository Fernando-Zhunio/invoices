using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using invoices.DTOs;
using invoices.Helper;
using invoices.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// TokenContext = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJleHAiOjE3MDQzMjI2MDZ9.gbMSLmD6HqmnJekFsZua6sLWDv7WRjq_PjBAkhBr1tw"
namespace invoices.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerApi
    {
        // private readonly ApplicationDbContext context;
        // private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthenticationController(
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IMapper mapper
        ): base(context, mapper)
        {
            // this.context = context;
            // this.mapper = mapper;
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response<ResponseRegisteAuth>>> Login([FromBody] CredentialsUserDto credentialsUser)
        {
            var user = await signInManager.PasswordSignInAsync(
                credentialsUser.Email,
                credentialsUser.Password,
                false,
                false
            );
            if (user == null)
            {
                return NotFound();
            }
            string userName = await userManager.GetUserNameAsync(await userManager.FindByEmailAsync(credentialsUser.Email));
            return ResponseOk<ResponseRegisteAuth>(GenerateClaimsIdentity(credentialsUser, userName));
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseRegisteAuth>> Register([FromBody] RegisterUserDto register)
        {
            var user = new IdentityUser { UserName = register.Name, Email = register.Email };
            var result = await userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                return ResponseOk<ResponseRegisteAuth>(GenerateClaimsIdentity(register, user.UserName));
            }
            return BadRequest(result);
        }

        private ResponseRegisteAuth GenerateClaimsIdentity(CredentialsUserDto credentialsUser, string name)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credentialsUser.Email),
                new Claim("name", name),
                // new Claim(ClaimTypes.NameIdentifier, id)
            };
            var keys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(keys, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new ResponseRegisteAuth
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration,
                name = name,
                email = credentialsUser.Email
            };
        }
    }
}
