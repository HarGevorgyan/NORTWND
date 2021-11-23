using System.Threading.Tasks;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface IRepositoryManager
    {
        public ICustomerRepository Customers { get; }

        public IUserRepository Users {  get; }
        void Save();
        Task SaveAsync();
    }
}
