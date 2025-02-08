using Store.Core.Entities;
using Store.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository.Data
{
    public static class StoreDbContextSeed
    {
        public async static Task SeedAsync(StoreDbContext context)
        {
            if (context.Brands.Count() == 0)
            {

                // read
                var brandsData = File.ReadAllText(@"C:\Users\SoftLaptop\source\repos\StoreAPP\Store.Repository\Data\DataSeed\brands.json");

                // convert
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands is not null && brands.Count > 0)
                {
                   await context.Brands.AddRangeAsync(brands);
                     await context.SaveChangesAsync();

                }
            }
            if (context.Types.Count() == 0)
            {

                // read
                var typesData = File.ReadAllText(@"C:\Users\SoftLaptop\source\repos\StoreAPP\Store.Repository\Data\DataSeed\types.json");

                // convert
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types is not null && types.Count > 0)
                {
                   await context.Types.AddRangeAsync(types);
                   await context.SaveChangesAsync();

                }
            }
            if (context.Products.Count() == 0)
            {

                // read
                var productsData = File.ReadAllText(@"C:\Users\SoftLaptop\source\repos\StoreAPP\Store.Repository\Data\DataSeed\products.json");

                // convert
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products is not null && products.Count > 0)
                {
                    await context.AddRangeAsync(products);
                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
