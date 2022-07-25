using Core.DTOs.Products;
using Core.Enums;
using Core.Services.ProductService;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<ProductDTO>>> GetProducts(string? category)
        {
            var result = await _productService.GetProducts(category);
            if(result == null)
            {
                return new ApiResponse<List<ProductDTO>>(Status.Faild, "ERROR", 404, result);
            }
            return new ApiResponse<List<ProductDTO>> (Status.Success, "OK", 200, result);
        }
    }
}
