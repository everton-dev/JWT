using Lab.Jwt.API.Models;
using Lab.Jwt.API.Repositories;
using Lab.Jwt.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Lab.Jwt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly IConfiguration _configuration;

        public SecurityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login(User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);

            if (user != null)
            {
                var token = TokenService.GerateToken(user);
                user.Password = "";
                return new
                {
                    user = user,
                    token = token
                };
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }
        }
    }
}