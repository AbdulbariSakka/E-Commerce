using Core.Enums;
using Core.Services.OrderService;
using Core.ViewModels;
using Core.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ApiResponse<long>> CreateOrder(CreateOrderRequest model)
        {
            var result = await _orderService.CreateOrder(model);
            if (result == 0)
            {
                return new ApiResponse<long>(Status.Faild, "ERROR", 404, result);
            }
            return new ApiResponse<long>(Status.Success, "OK", 200, result);
        }
    }
}
