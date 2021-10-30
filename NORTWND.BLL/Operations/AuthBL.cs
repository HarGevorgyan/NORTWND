using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Entities;
using NORTWND.Core.Exceptions;
using NORTWND.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.BLL.Operations
{
    public class AuthBL : IAuthBL
    {
        private readonly IRepositoryManager _repositories;

        private bool logged = false;
        public AuthBL(IRepositoryManager repositories)
        {
            _repositories = repositories;
        }

        public async Task LoginAsync(LoginModel login, HttpContext context)
        {
            if (logged) throw new LogicException("You have already logged in");

            var user = _repositories.Users.GetWhere(x => x.UserName == login.UserName && x.Password == login.Password);
            if (!user.Any()) throw new LogicException("Wrong username or password !!");

            await Authenticate(user.FirstOrDefault(), context);
            logged = true;
        }

        public async Task LogoutAsync(HttpContext context)
        {
            if (logged)
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            else throw new LogicException("You haven't logged in");
        }

        public async Task<UserViewModel> RegisterAsync(RegisterModel register)
        {
            if (logged) throw new LogicException("You have already logged in");

            var users = _repositories.Users.GetWhere(x => x.UserName.ToUpper() == register.UserName.ToUpper());

            if (users.Any()) throw new LogicException("Username already exists");
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
