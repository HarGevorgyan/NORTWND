using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Entities;
using NORTWND.Core.Exceptions;
using NORTWND.Core.Models;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using NORTWND.Core.Enums;
using Microsoft.Extensions.Logging;

namespace NORTWND.BLL.Operations
{
    public class AuthBL : IAuthBL
    {
        private readonly IRepositoryManager _repositories;
        private readonly ILogger<AuthBL> _logger;
        public AuthBL(IRepositoryManager repositories, ILogger<AuthBL> logger)
        {
            _repositories = repositories;
            _logger = logger;
        }

        public async Task LoginAsync(LoginModel login, HttpContext context)
        {
            _logger.LogInformation("Login Started");
            var user = _repositories.Users.GetWhere(x => x.UserName == login.UserName && x.Password == login.Password);
            if (!user.Any()) throw new LogicException("Wrong username or password !!");

            await Authenticate(user.FirstOrDefault(), context);

        }

        public async Task LogoutAsync(HttpContext context)
        {

            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        }

        public async Task<UserViewModel> RegisterAsync(RegisterModel register)
        {

            var users = _repositories.Users.GetWhere(x => x.UserName.ToUpper() == register.UserName.ToUpper());

            if (users.Any()) throw new LogicException("Username already exists", HttpStatusCode.BadRequest);
            var user = new User
            {
                Role = Core.Enums.Role.Standart,
                UserName = register.UserName,
                Password = register.Password,
                Name = register.Name,
                LastName = register.LastName

            };
            _repositories.Users.Add(user);
            await _repositories.Users.SaveChangesAsync();

            return new UserViewModel
            {
                Name = user.Name,
                LastName = user.LastName,
                Role = user.Role.ToString()
            };
        }
        public async Task<UserViewModel> EditUserAsync( UserEditModel model)
        {
            var user = _repositories.Users.GetWhere(x => x.UserName.ToUpper() == model.OldUserName.ToUpper()&&x.Password.ToUpper()==model.OldPassword.ToUpper()).FirstOrDefault();
            if (user == null) throw new LogicException("Incorrect username");

            user.UserName = string.IsNullOrEmpty(model.UserName) ? user.UserName : model.UserName;
            user.Password = string.IsNullOrEmpty(model.Password) ? user.Password : model.Password;
            user.LastName = string.IsNullOrEmpty(model.LastName) ? user.LastName : model.LastName;
            user.Name = string.IsNullOrEmpty(model.Name) ? user.Name : model.Name;

            _repositories.Users.Update(user);
            await _repositories.Users.SaveChangesAsync();

            return new UserViewModel { Name = user.Name, LastName = user.LastName, Role = user.Role.ToString() };

        }
        public async Task RolesChangeAsync(RolesChangeModel model)
        {
            var user = _repositories.Users.GetWhere(x => x.UserName.ToUpper() == model.UserName.ToUpper()).FirstOrDefault();
            if (user == null) throw new LogicException("Incorrect username !!");

            user.Role =  (model.Role == 2) ? Role.Moderator : (model.Role == 3) ? Role.Admin : Role.Standart;

            _repositories.Users.Update(user);
            await _repositories.Users.SaveChangesAsync();

        }
        private async Task Authenticate(User user, HttpContext context)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role.ToString())
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
