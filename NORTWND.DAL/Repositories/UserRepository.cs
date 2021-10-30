using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Entities;

namespace NORTWND.DAL.Repositories
{
    public class UserRepository:RepositoryBase<User>,IUserRepository
    {
        private NORTHWNDContext context;

        public UserRepository(NORTHWNDContext context) : base(context) { }
        
    }
}