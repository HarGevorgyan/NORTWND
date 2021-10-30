using NORTWND.Core.Entities;
using NORTWND.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
