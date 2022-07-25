using AutoMapper;
using Core.Data;
using Core.Entities.Orders;
using Core.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<long> CreateOrder(CreateOrderRequest model)
        {
            try
            {
                Order entity = _mapper.Map<Order>(model);

                entity.TotalAmount = model.Details.Select(a => a.Amount).ToList().Sum();
                //Order orderEntity = new Order
                //{
                //    CustomerName = model.CustomerName,
                //    CustomerEmail = model.CustomerEmail,
                //    CustomerGSM = model.CustomerGSM,
                //    TotalAmount = model.ProductDetails.Select(a => a.Amount).ToList().Sum()
                //};

                //await _context.AddAsync(orderEntity);

                //var orderDetails = model.ProductDetails.Select(a => new OrderDetail {
                //    OrderId = orderEntity.Id,
                //    ProductId = a.ProductId,
                //    UnitPrice = a.UnitPrice
                //}).ToList();

                //orderEntity.OrderDetails = orderDetails;

                //_context.Update(orderEntity);
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity.Id;

            }catch (Exception ex)
            {
                // TODO: Logging
                return 0;
            }
            


        }
    }
}
