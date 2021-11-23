using Microsoft.EntityFrameworkCore;
using NORTWND.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTWND.DAL.BigOperations
{
    public class BigCustomers 
    {
        NORTHWNDContext _db = new NORTHWNDContext();
        public async Task<IEnumerable<CustomerViewModel>> OrderByRegion()
        {
            var response = await _db.Customers
                .OrderBy(o => o.Region == null ? 1 : 0).ToListAsync();

            return response.Select(x => new CustomerViewModel
            {
                CustomerId = x.CustomerId,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                Country = x.Country,
                City = x.City,
                Region = x.Region,
            });

        }

        public async Task<IEnumerable<TotalCustomersViewModel>> TotalCustomers()
        {
            var response = await _db.Customers
                .GroupBy(x => new { x.Country, x.City })
                .Select(x => new TotalCustomersViewModel
                {
                    Country = x.Key.Country,
                    City = x.Key.City,
                    Customers = x.Select(x => x.CustomerId).Count()
                }).OrderByDescending(x => x.Customers).ToListAsync();

            return response.Select(x => new TotalCustomersViewModel
            {
                
                Country = x.Country,
                City = x.City,
                Customers = x.Customers
            });
        }
    }
}
