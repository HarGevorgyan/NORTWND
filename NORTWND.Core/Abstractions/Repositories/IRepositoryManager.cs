using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface IRepositoryManager
    {
        public ICustomerRepository Customers { get; }
        void Save();
        Task SaveAsync();
    }
}
