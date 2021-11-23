using NORTWND.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface ICustomersBL
    {
        Task<IEnumerable<TotalCustomersViewModel>> TotalCustomers();
        Task<IEnumerable<CustomerViewModel>> OrderByRegion();
        Task<CustomerViewModel> AddCustomerAsync(CustomerAddModel model);
        Task EditCustomerAsync(string customerId, CustomerEditModel model);
        Task RemoveCustomerAsync(string customerId);
        Task<IEnumerable<CustomerViewModel>> GetCustomersAsync(CustomerFilterModel filter);
    }
}
