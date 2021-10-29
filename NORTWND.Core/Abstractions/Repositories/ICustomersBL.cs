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
        Task<IEnumerable<CustomersViewModel>> TotalCustomers();
        Task<IEnumerable<CustomersViewModel>> OrderByRegion();
    }
}
