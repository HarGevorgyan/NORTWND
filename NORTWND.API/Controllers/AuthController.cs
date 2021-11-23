using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Models;
using Serilog;
using System.Threading.Tasks;

namespace NORTWND.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBL _auth;

        public AuthController(IAuthBL auth)
        {
            _auth = auth;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel login)
        {
            await _auth.LoginAsync(login, HttpContext);
            return Ok();
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutAsync()
        {
            Log.Information("Logout");

            await _auth.LogoutAsync(HttpContext);
            return Ok();
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel register)
        {
            var user = await _auth.RegisterAsync(register);

            return Created("", user);
        }
        [HttpPut("edit")]
        [Authorize]
        public async Task<IActionResult> EditUser([FromBody] UserEditModel model)
        {
            var user = await _auth.EditUserAsync(model);
            return Created("",user);
        }

        [HttpPut("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RolesChange([FromBody] RolesChangeModel model)
        {
            await _auth.RolesChangeAsync(model);

            return Ok();
        }

    }
}
