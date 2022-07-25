using Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Orders
{
    public class OrderDetail : BaseEntity<long>
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
    }
}
