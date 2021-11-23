using NORTWND.Core.Entities;
using NORTWND.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface ICustomerRepository:IRepositoryBase<Customer>
    {
        Task<IEnumerable<CustomerViewModel>> GetFilteredCustomer(CustomerFilterModel filter);
    }
}
