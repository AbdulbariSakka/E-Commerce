using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Orders
{
    public class Order : BaseEntity<long>
    {
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerGSM { get; set; }

        public int TotalAmount { get;set; }

        public List<OrderDetail> Details { get; set; }
    }
}
