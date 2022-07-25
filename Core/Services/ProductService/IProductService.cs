using Core.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.ProductService
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProducts(string category);
    }
}
