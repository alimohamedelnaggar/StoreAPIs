using AutoMapper;
using Store.Core;
using Store.Core.Dtos.Products;
using Store.Core.Dtos.TypeBrand;
using Store.Core.Entities;
using Store.Core.Services.Contract;
using Store.Core.Specifications.ProductSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TypeBrandDto>> GetAllBrandAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync());
        }



        public async Task<IEnumerable<TypeBrandDto>> GetAllTypeAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync());
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync(string? sort)
        {
            var spec = new ProductSpecifications(sort);
            return _mapper.Map<IEnumerable<ProductDto>>(await _unitOfWork.Repository<Product, int>().GetAllWithSpecAsync(spec));
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var spec = new ProductSpecifications(id);
            var product = await _unitOfWork.Repository<Product, int>().GetWithSpecAsync(spec);
            var mappedProduct = _mapper.Map<ProductDto>(product);
            return mappedProduct;
        }


    }
}
