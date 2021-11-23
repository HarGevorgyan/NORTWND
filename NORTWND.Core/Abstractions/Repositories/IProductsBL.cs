using NORTWND.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface IProductsBL
    {
        Task<IEnumerable<ProductViewModel>> NeedReordering();
        Task<IEnumerable<ProductViewModel>> NeedReorderingContinued();
    }
}
