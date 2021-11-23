
using NORTWND.Core.Abstractions.Repositories;
using NORTWND.DAL.BigOperations;
using System.Collections.Generic;
using System.Threading.Tasks;
using NORTWND.Core.Models;

namespace NORTWND.BLL.Operations
{
    public class OrdersBL : IOrdersBL
    {


        private BigOrders orders = new BigOrders();


        public Task<IEnumerable<OrdersAvg>> AvgFreightAsync()
        {
            return orders.AvgFreightAsync();
        }
        public Task<IEnumerable<OrdersAvg>> AvgFreight98()
        {
            return orders.AvgFreight98();
        }
    }
}
