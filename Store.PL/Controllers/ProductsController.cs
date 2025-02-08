using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Services.Contract;

namespace Store.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAllProduct([FromQuery]string? sort) 
        {
            var result=await _productService.GetAllProductAsync(sort);
            return Ok(result);
        } 

        [HttpGet("brands")]

        public async Task<IActionResult> GetAllBrand() 
        {
            var result=await _productService.GetAllBrandAsync();
            return Ok(result);
        } 
        [HttpGet("Types")]

        public async Task<IActionResult> GetAllType() 
        {
            var result=await _productService.GetAllTypeAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int? id) 
        {
            if (id is null)
            {
                return BadRequest();
            }
            var result= await _productService.GetProductById(id.Value);
            if (result is null) 
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
