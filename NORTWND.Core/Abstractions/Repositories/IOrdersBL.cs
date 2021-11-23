using System.Collections.Generic;
using System.Threading.Tasks;
using NORTWND.Core.Models;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface IOrdersBL
    {
        Task<IEnumerable<OrdersAvg>> AvgFreightAsync();
        Task<IEnumerable<OrdersAvg>> AvgFreight98();

    }
}
