using api.Data;
using api.DTOs.Transaction;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllAsync()
        {
            return await _context.Transactions
                .Select(t => new TransactionDto
                {
                    Id = t.Id,
                    ProductId = t.ProductId,
                    EmployeeId = t.EmployeeId,
                    Type = t.Type,
                    Quantity = t.Quantity,
                    TotalPrice = t.TotalPrice,
                    Date = t.Date
                })
                .ToListAsync();
        }

        public async Task<TransactionDto> StockInAsync(StockInDto dto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == dto.ProductId);

            if (product == null)
                throw new Exception("Product not found");

            product.Quantity += dto.Quantity;

            var transaction = new Models.Transaction
            {
                ProductId = dto.ProductId,
                EmployeeId = dto.EmployeeId,
                Quantity = dto.Quantity,
                Type = "IN",
                TotalPrice = product.Price * dto.Quantity,
                Date = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();

            return new TransactionDto
            {
                Id = transaction.Id,
                ProductId = transaction.ProductId,
                EmployeeId = transaction.EmployeeId,
                Quantity = transaction.Quantity,
                Type = transaction.Type,
                TotalPrice = transaction.TotalPrice,
                Date = transaction.Date
            };
        }

        public async Task<TransactionDto> StockOutAsync(StockOutDto dto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == dto.ProductId);

            if (product == null)
                throw new Exception("Product not found");

            if (product.Quantity < dto.Quantity)
                throw new Exception("Not enough stock");

            product.Quantity -= dto.Quantity;

            var transaction = new Models.Transaction
            {
                ProductId = dto.ProductId,
                EmployeeId = dto.EmployeeId,
                Quantity = dto.Quantity,
                Type = "OUT",
                TotalPrice = product.Price * dto.Quantity,
                Date = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();

            return new TransactionDto
            {
                Id = transaction.Id,
                ProductId = transaction.ProductId,
                EmployeeId = transaction.EmployeeId,
                Quantity = transaction.Quantity,
                Type = transaction.Type,
                TotalPrice = transaction.TotalPrice,
                Date = transaction.Date
            };
        }

    }
}