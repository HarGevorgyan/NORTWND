using Microsoft.EntityFrameworkCore;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Entities;
using NORTWND.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTWND.DAL.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(NORTHWNDContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CustomerViewModel>> GetFilteredCustomer(CustomerFilterModel filter)
        {
            var response = _context.Customers.AsQueryable();
            if (!string.IsNullOrEmpty(filter.CustomerId))
            {
                response = _context.Customers.Where(x=>x.CustomerId == filter.CustomerId);
                 
            }
            if (!string.IsNullOrEmpty(filter.CompanyName))
            {
                response = _context.Customers.Where(x=>x.CompanyName==filter.CompanyName);
            }

            return await  response.Select(x=> new CustomerViewModel
            {
                CustomerId = x.CustomerId,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                City = x.City,
                Country = x.Country,
                Region = x.Region
            }).ToListAsync();
            
       }
    }
}
