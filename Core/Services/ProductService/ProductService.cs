using AutoMapper;
using Core.Data;
using Core.DTOs.Products;
using Core.Services.Caching;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.ProductService
{
    public class ProductService : IProductService
    {
        #region Fields and CTOR
        private readonly ApplicationDbContext _context;
        private readonly ICacheService<List<ProductDTO>> _cacheService;

        private List<ProductDTO> _products;
        public ProductService(ApplicationDbContext context, ICacheService<List<ProductDTO>> cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        #endregion

        public async Task<List<ProductDTO>> GetProducts(string category)
        {
            try
            {
                var products = await _cacheService.GetAsync("productsCacheKey" + category);
                
                if(products == null)
                {
                    var query = _context.Products.AsQueryable().AsNoTracking();
                    if (category != null)
                    {
                        query = query.Where(p => p.Category == category);
                    }
                    products = await query.Select(p => new ProductDTO
                    {
                        Id = p.Id,
                        Category = p.Category,
                        Description = p.Description,
                        Unit = p.Unit,
                        UnitPrice = p.UnitPrice
                    }).ToListAsync();
                    await _cacheService.SetAsync("productsCacheKey" + category, products, TimeSpan.FromDays(30));
                }

                return products;
            }catch (Exception ex)
            {
                // TODO: Logging
                return null;
            }
        }
    }
}
