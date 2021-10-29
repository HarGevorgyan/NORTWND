using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Models;
using NORTWND.DAL.BigOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.BLL.Operations
{
    public class CustomersBL : ICustomersBL
    {
        private BigCustomers customers = new BigCustomers();
        public async Task<IEnumerable<CustomersViewModel>> OrderByRegion()
        {
            return await customers.OrderByRegion();
        }

        public async Task<IEnumerable<CustomersViewModel>> TotalCustomers()
        {
            return await customers.TotalCustomers();
        }
    }
}
