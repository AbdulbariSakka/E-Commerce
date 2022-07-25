using AutoMapper;
using Core.Services.Caching;
using Core.Services.OrderService;
using Core.Services.ProductService;

namespace E_Commerce.Extensions
{
    public static class StartupExtension
    {
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            // Add Caching Services
            services.AddMemoryCache();
            services.AddScoped(typeof(ICacheService<>),typeof(CacheService<>));

            services.AddScoped<IOrderService, OrderService>();

            #region Mapper 

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            #endregion
        }
    }
}
