using Microsoft.AspNetCore.Mvc;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Entities;
using System.Threading.Tasks;

namespace NORTWND.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController:ControllerBase
    {
        IOrdersBL _orders;

        public OrdersController(IOrdersBL orders)
        {
            _orders = orders;
        }

        [HttpGet("avg_freight")]//25
        public async Task<IActionResult> AvgFreightAsync()
        {
            var response =  await _orders.AvgFreightAsync();

            return (response!=null)? Ok(response):NoContent();
        }

        [HttpGet("avg_freight_1998")]//26
      public async Task<IActionResult> AvgFreight98Async()
        {
            var response = _orders.AvgFreight98();

            return (response != null) ? Ok(response) : NoContent();
        }


    }
}
