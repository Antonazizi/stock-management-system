using api.Data;
using api.DTOs.Product;
using api.Models;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _context.Products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category,
                    Type = p.Type,
                    Size = p.Size,
                    Color = p.Color,
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .ToListAsync();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p == null) return null;

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Type = p.Type,
                Size = p.Size,
                Color = p.Color,
                Price = p.Price,
                Quantity = p.Quantity
            };
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Category = dto.Category,
                Type = dto.Type,
                Size = dto.Size,
                Color = dto.Color,
                Price = dto.Price,
                Quantity = dto.Quantity,
                MinStockLevel = dto.MinStockLevel
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Type = product.Type,
                Size = product.Size,
                Color = product.Color,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        public async Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Name = dto.Name;
            product.Category = dto.Category;
            product.Type = dto.Type;
            product.Size = dto.Size;
            product.Color = dto.Color;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;
            product.MinStockLevel = dto.MinStockLevel;

            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Type = product.Type,
                Size = product.Size,
                Color = product.Color,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}