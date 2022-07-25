using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Products
{
    public class ProductDTO
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Unit { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
