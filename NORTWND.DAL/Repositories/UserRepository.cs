using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Entities;

namespace NORTWND.DAL.Repositories
{
    public class UserRepository:RepositoryBase<User>,IUserRepository
    {
         public UserRepository(NORTHWNDContext context) : base(context) { }
        
    }
}