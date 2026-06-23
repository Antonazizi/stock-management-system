using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Services.Interfaces;
using api.DTOs.Product;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(CreateProductDto product)
        {
            var createdProduct = await _productService.CreateAsync(product);
            return Ok(createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto product)
        {
            var updatedProduct = await _productService.UpdateAsync(id, product);

            if (updatedProduct == null)
                return NotFound();

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return Ok(new {message = "Deleted successfully"});
        }
    }
}