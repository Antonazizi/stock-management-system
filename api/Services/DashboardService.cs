using api.Data;
using api.DTOs.Dashboard;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            var totalProducts = await _context.Products.CountAsync();
            var totalEmployees = await _context.Employees.CountAsync();
            var totalTransactions = await _context.Transactions.CountAsync();

            var lowStock = await _context.Products
                .CountAsync(p => p.Quantity > 0 && p.Quantity < p.MinStockLevel);

            var outOfStock = await _context.Products
                .CountAsync(p => p.Quantity == 0);

            var totalSales = await _context.Transactions
                .Where(t => t.Type == "OUT")
                .SumAsync(t => t.TotalPrice);

            return new DashboardDto
            {
                TotalProducts = totalProducts,
                TotalEmployees = totalEmployees,
                TotalTransactions = totalTransactions,
                LowStockProducts = lowStock,
                OutOfStockProducts = outOfStock,
                TotalSales = totalSales
            };
        }

        public async Task<IEnumerable<LowStockProductDto>> GetLowStockProductsAsync()
        {
            return await _context.Products
                .Where(p => p.Quantity < p.MinStockLevel)
                .Select(p => new LowStockProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = p.Quantity,
                    MinStockLevel = p.MinStockLevel
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<TopSellingProductDto>> GetTopSellingProductsAsync()
        {
            return await _context.Transactions
                .Where(t => t.Type == "OUT")
                .Include(t => t.Product)
                .GroupBy(t => new
                {
                    t.ProductId,
                    t.Product.Name
                })
                .Select(g => new TopSellingProductDto
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.Name,
                    TotalSold = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.TotalSold)
                .Take(5)
                .ToListAsync();
        }

        public async Task<IEnumerable<MonthlySalesDto>> GetMonthlySalesAsync()
        {
            return await _context.Transactions
                .Where(t => t.Type == "OUT")
                .GroupBy(t => t.Date.Month)
                .Select(g => new MonthlySalesDto
                {
                    Month = g.Key,
                    TotalSales = g.Sum(x => x.TotalPrice)
                })
                .OrderBy(x => x.Month)
                .ToListAsync();
        }

        public async Task<IEnumerable<RecentTransactionDto>> GetRecentTransactionsAsync()
        {
            return await _context.Transactions
                .Include(t => t.Product)
                .Include(t => t.Employee)
                .OrderByDescending(t => t.Date)
                .Take(10)
                .Select(t => new RecentTransactionDto
                {
                    ProductName = t.Product.Name,
                    EmployeeName = t.Employee.Name,
                    Type = t.Type,
                    Quantity = t.Quantity,
                    Date = t.Date
                })
                .ToListAsync();
        }
    }
}