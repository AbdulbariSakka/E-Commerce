using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.Orders
{
    public class ProductDetails
    {
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Amount { get; set; }
    }
}
