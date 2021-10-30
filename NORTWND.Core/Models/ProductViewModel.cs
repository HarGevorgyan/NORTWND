using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.Core.Models
{
    public class ProductViewModel
    {
         public int ProductId {  get; set; }
        public string ProductName {  get; set; }
         public short? UnitsInStock {  get; set; }
        public short? UnitsOnOrder {  get; set; }
        public short? ReorderLevel {  get; set; }
        public bool Discontinued {  get; set; }
    }
}
