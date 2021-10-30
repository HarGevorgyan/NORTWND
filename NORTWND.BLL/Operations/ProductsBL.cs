using NORTWND.Core.Abstractions.Repositories;
using NORTWND.Core.Models;
using NORTWND.DAL.BigOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.BLL.Operations
{

    public class ProductsBL : IProductsBL
    {
        private BigProducts products = new BigProducts();
        public Task<IEnumerable<ProductViewModel>> NeedReordering()
        {
            return products.NeedReordering();
        }

        public Task<IEnumerable<ProductViewModel>> NeedReorderingContinued()
        {
            return products.NeedReorderingContinued();
        }
    }
}
