using Core.Entities.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public static class SeedDataExtension
    {
        public static void SeedData(this IApplicationBuilder applicationBuilder)
        {
            SeedProducts(applicationBuilder);
        }
        private static void SeedProducts(IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            if (!context.Products.Any())
            {


                List<Product> products = new List<Product>();

                for (int i = 1; i <= 1000; i++)
                {
                    Product product = new Product
                    {
                        Description = "Description-" + i.ToString(),
                        Category = "Category-" + (i % 10).ToString(),
                        Unit = "Unit-" + (i % 10).ToString(),
                        UnitPrice = i % 10,
                        Status = (i % 2).Equals(0),
                        CreateDate = DateTime.UtcNow,
                    };

                    products.Add(product);
                }

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
