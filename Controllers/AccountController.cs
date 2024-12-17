using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StarshipServer.Data;
using StarshipServer.Data.Models;
using System.IdentityModel.Tokens.Jwt;

namespace StarshipServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtHandler _jwtHandler;

        public AccountController(
            ApplicationDbContext context, UserManager<ApplicationUser> userManager, JwtHandler jwtHandler)
        {
            _context = context;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(ApiLoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                return Unauthorized(new ApiLoginResult() { Success = false, Message = "These aren't the droids you're looking for." });
            }

            var secToken = await _jwtHandler.GetTokenAsync(user);
            var jwt = new JwtSecurityTokenHandler().WriteToken(secToken);

            return Ok(new ApiLoginResult()
            {
                Success = true,
                Message = "May the Force be with you.",
                Token = jwt
            });
        }
    }
}
