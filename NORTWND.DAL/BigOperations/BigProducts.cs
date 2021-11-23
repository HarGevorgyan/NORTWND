using Microsoft.EntityFrameworkCore;
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTWND.DAL.BigOperations
{
    public class BigProducts : IProductsBL
    {
        NORTHWNDContext _db = new NORTHWNDContext();
        public async Task<IEnumerable<ProductViewModel>> NeedReordering()
        {
            var response = await _db.Products.Where(p => p.UnitsOnOrder < p.ReorderLevel).OrderBy(p => p.ProductId).ToListAsync();

            return response.Select(x => new ProductViewModel
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued

            });
        }

        public async Task<IEnumerable<ProductViewModel>> NeedReorderingContinued()
        {
            var response = await _db.Products
                            .Where(p => (p.UnitsOnOrder + p.UnitsInStock) <= p.ReorderLevel && p.Discontinued == false)
                            .OrderBy(p => p.ProductId).ToListAsync();

            return response.Select(x => new ProductViewModel
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued
            });
        }
    }
}
