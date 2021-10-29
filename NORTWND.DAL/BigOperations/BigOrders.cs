using Microsoft.EntityFrameworkCore;
using NORTWND.Core.Abstractions;
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
    public class BigOrders : IOrdersBL
    {

       
        public  async Task<IEnumerable<OrdersAvg>> AvgFreightAsync()
        {
            using NORTHWNDContext _db = new NORTHWNDContext();
            var response = await _db.Orders.Select(p => new { p.ShipCountry, p.Freight }).
                GroupBy(g => g.ShipCountry).Select(g => new 
                {
                    ShipCountry = g.Key,
                    AvgFreight = (double)g.Average(g => g.Freight)
                }).Take(3).OrderBy(x => x.AvgFreight).ToListAsync();

            return  response.Select(x=>new OrdersAvg
            {
                ShipCountry = x.ShipCountry,
                AvgFreight = x.AvgFreight
            });
        }

        public async Task<IEnumerable<OrdersAvg>> AvgFreight98()
        {
            using NORTHWNDContext _db = new NORTHWNDContext();

            var response = await _db.Orders.Select(p => new { p.ShipCountry, p.Freight, p.OrderDate }).Where(d => d.OrderDate.Value.Year == 1998).
                GroupBy(g => g.ShipCountry).Select(g => new
                {
                    ShipCountry = g.Key,
                    AvgFreight =(double) g.Average(g => g.Freight)
                }).Take(3).OrderBy(x => x.AvgFreight).ToListAsync();

            return response.Select(x => new OrdersAvg { ShipCountry = x.ShipCountry, AvgFreight = x.AvgFreight });
        }

        
    }
}
