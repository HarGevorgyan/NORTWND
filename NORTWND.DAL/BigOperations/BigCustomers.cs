using Microsoft.EntityFrameworkCore;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Entities;
using NORTWND.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.DAL.BigOperations
{
    public class BigCustomers : ICustomersBL
    {
        NORTHWNDContext _db = new NORTHWNDContext();
        public async Task<IEnumerable<CustomersViewModel>> OrderByRegion()
        {
            var response = await _db.Customers
                .OrderBy(o => o.Region == null ? 1 : 0).ToListAsync();

            return response.Select(x => new CustomersViewModel
            {
                CustomerId = x.CustomerId,
                CompanyName = x.CompanyName,
                Country = x.Country,
                City = x.City,
                Region = x.Region,
            });

        }

        public async Task<IEnumerable<CustomersViewModel>> TotalCustomers()
        {
            var response = await _db.Customers
                .GroupBy(x => new { x.Country, x.City })
                .Select(x => new CustomersViewModel
                {
                    Country = x.Key.Country,
                    City = x.Key.City,
                    Customers = x.Select(x => x.CustomerId).Count()
                }).OrderByDescending(x => x.Customers).ToListAsync();

            return response.Select(x => new CustomersViewModel
            {
                CustomerId = x.CustomerId,
                CompanyName = x.CompanyName,
                Country = x.Country,
                City = x.City,
                Region = x.Region,
                Customers = x.Customers
            });
        }
    }
}
