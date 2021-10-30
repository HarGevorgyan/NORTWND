using Microsoft.AspNetCore.Http;
using NORTWND.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface IAuthBL
    {
        Task LoginAsync(LoginModel login, HttpContext context);
        Task LogoutAsync(HttpContext context);

        Task<UserViewModel> RegisterAsync(RegisterModel register);


    }
}
