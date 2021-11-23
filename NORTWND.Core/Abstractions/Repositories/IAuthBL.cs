using Microsoft.AspNetCore.Http;
using NORTWND.Core.Models;
using System.Threading.Tasks;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface IAuthBL
    {
        Task LoginAsync(LoginModel login, HttpContext context);
        Task LogoutAsync(HttpContext context);
        Task<UserViewModel> RegisterAsync(RegisterModel register);

        Task<UserViewModel> EditUserAsync(UserEditModel model);
        Task RolesChangeAsync(RolesChangeModel model);


    }
}
