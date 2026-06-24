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
    }
}