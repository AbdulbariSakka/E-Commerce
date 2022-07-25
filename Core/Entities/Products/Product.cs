using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Products
{
    public class Product : BaseEntity<long>
    {
        public string Description { get; set; }

        public string Category { get; set; }

        public string Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
