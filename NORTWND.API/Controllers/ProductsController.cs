﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NORTWND.API.Entities;
using NORTWND.Core.Abstractions.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace NORTWND.Controllers
{
   [ApiController]
    [Route("[controller]")]
    public class ProductsController:ControllerBase
    {
        IProductsBL _products;
        //NORTHWNDContext _db;

       public ProductsController(IProductsBL products) { _products = products; }

        [HttpGet("need_reordering")]//22

        public async Task<IActionResult> NeedReorderingAsync()
        {
           var response = await _products.NeedReordering();

            return (response!=null)?Ok(response) : NoContent();
        }

        [HttpGet("need_reordering_continued")]//23

        public async Task<IActionResult> NeedReorderingContinuedAsync()
        {
            var response =await  _products.NeedReorderingContinued();
            return (response!=null)?Ok(response) : NoContent();
        }
    }
}
