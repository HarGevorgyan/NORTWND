using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Models;
using System.Threading.Tasks;

namespace NORTWND.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthBL _auth;

        public AuthController(IAuthBL auth)
        {
            _auth = auth;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel login)
        {
            await _auth.LoginAsync(login, HttpContext);
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await _auth.LogoutAsync(HttpContext);
            return Ok();
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel register)
        {
            var user =await  _auth.RegisterAsync(register);

            return Created("", user);
        }
    }
}
