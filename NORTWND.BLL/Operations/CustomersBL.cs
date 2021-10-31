using Microsoft.Extensions.Logging;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Entities;
using NORTWND.Core.Exceptions;
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

        private readonly IRepositoryManager _repositories;

        public CustomersBL(IRepositoryManager repositories)
        {
            _repositories = repositories;
           
        }

        public async Task<CustomerViewModel> AddCustomerAsync(CustomerAddModel model)
        {
            var customer = new Customer
            {
                CustomerId = model.CustomerId,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Address = model.Address,
                City = model.City,
                Region = model.Region,
                PostalCode = model.PostalCode,
                Country = model.Country,
                Phone = model.Phone,
                Fax = model.Fax,
            };
            _repositories.Customers.Add(customer);

            await _repositories.SaveAsync();

            return new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                City = customer.City,
                Country = customer.Country,
                Region = customer.Region,
            };

        }

        public async Task EditCustomerAsync(string customerId, CustomerEditModel model)
        {
            var customer = await _repositories.Customers.GetAsync(customerId)??
                throw new LogicException("Wrong CustomerId");

            customer.ContactName = string.IsNullOrEmpty(model.ContactName)?customer.ContactName: model.ContactName;
            customer.ContactTitle = string.IsNullOrEmpty(model.ContactTitle) ? customer.ContactTitle : model.ContactTitle;
            customer.City = string.IsNullOrEmpty(model.City) ? customer.City : model.City;
            customer.Address = string.IsNullOrEmpty(model.Address) ? customer.Address : model.Address;
            customer.Country = string.IsNullOrEmpty(model.Country) ? customer.Country : model.Country;
            customer.Phone = string.IsNullOrEmpty(model.Phone) ? customer.Phone : model.Phone;
            customer.Region = string.IsNullOrEmpty(model.Region) ? customer.Region : model.Region;
            customer.PostalCode = string.IsNullOrEmpty(model.PostalCode) ? customer.PostalCode : model.PostalCode;
            customer.Fax = string.IsNullOrEmpty(model.Fax) ? customer.Fax : model.Fax;

             _repositories.Customers.Update(customer);

            await _repositories.SaveAsync();


        }

             

        public async Task<IEnumerable<CustomerViewModel>> GetCustomersAsync(CustomerFilterModel filter)
        {
            var customers = await _repositories.Customers.GetFilteredCustomer(filter)??
                throw new LogicException("Wrong Customer ID or CompanyName");
            return customers;
        }

      

        public async Task<IEnumerable<CustomerViewModel>> OrderByRegion()
        {
            return await customers.OrderByRegion();
        }

     

        public async Task<IEnumerable<TotalCustomersViewModel>> TotalCustomers()
        {
            return await customers.TotalCustomers();
        }

        public async Task RemoveCustomerAsync(string customerId)
        {
            var customer = await _repositories.Customers.GetAsync(customerId)??
                throw new LogicException("Wrong Customer Id");

            _repositories.Customers.Remove(customer);

                await _repositories.SaveAsync();
        }
    }
}
