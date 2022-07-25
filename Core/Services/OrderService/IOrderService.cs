using Core.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.OrderService
{
    public interface IOrderService
    {
        Task<long> CreateOrder(CreateOrderRequest model);
    }
}
