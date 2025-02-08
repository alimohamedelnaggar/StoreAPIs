using Store.Core.Dtos.Products;
using Store.Core.Dtos.TypeBrand;
using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services.Contract
{
    public interface IProductService
    {
       Task<IEnumerable<ProductDto>> GetAllProductAsync(string? sort);
       Task<IEnumerable<TypeBrandDto>> GetAllBrandAsync();
       Task<IEnumerable<TypeBrandDto>> GetAllTypeAsync();
        Task<ProductDto> GetProductById(int id);
    }
}
