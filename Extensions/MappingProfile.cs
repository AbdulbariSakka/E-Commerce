using AutoMapper;
using Core.DTOs.Products;
using Core.Entities.Orders;
using Core.Entities.Products;
using Core.ViewModels.Orders;

namespace E_Commerce.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Order, CreateOrderRequest>().ReverseMap();

            CreateMap<OrderDetail, ProductDetails>().ReverseMap();
            
        }
    }
}
