using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NORTWND.API.Entities;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Models;
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
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCustomerAsync([FromQuery] CustomerFilterModel filter)
        {
           var response = await _customers.GetCustomersAsync(filter);

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCustomerAsync([FromBody] CustomerAddModel customer)
        {
            var response = await _customers.AddCustomerAsync(customer);

            return Created("Customer has been created",response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Moderator")]
        
        public async Task<IActionResult>  EditCustomerAsync([FromRoute] string id,[FromBody] CustomerEditModel model)
        {
            await _customers.EditCustomerAsync(id,model);

            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveCustomerAsync([FromRoute] string id)
        {
            await _customers.RemoveCustomerAsync(id);

            return Ok();
        }
    }
}
