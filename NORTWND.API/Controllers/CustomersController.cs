using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NORTWND.API.Entities;
using NORTWND.Core.Abstractions.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace NORTWND.API.Controllers
{ 
    public class CustomersController : ControllerBase
    {
        ICustomersBL _customers;
        public CustomersController(ICustomersBL customers)
        {
            _customers = customers;
        }
        [HttpGet("total_customers")]//21
        public async Task<IActionResult> TotalCustomersAsync()
        {
            var response = await  _customers.TotalCustomers();

            return  (response!=null) ? Ok(response) : NoContent();
        }
        [HttpGet("order")]//24
        public async Task<IActionResult> OrderByRegionAsync()
        {
            var response = await _customers.OrderByRegion();

            return (response!= null) ? Ok(response) : NoContent();
        }
    }
}
