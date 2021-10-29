using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NORTWND.Core.Models;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface IOrdersBL
    {
        Task<IEnumerable<OrdersAvg>> AvgFreightAsync();
        Task<IEnumerable<OrdersAvg>> AvgFreight98();

    }
}
