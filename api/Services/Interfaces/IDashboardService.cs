using api.DTOs.Dashboard;

namespace api.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
        Task<IEnumerable<LowStockProductDto>> GetLowStockProductsAsync();
        Task<IEnumerable<TopSellingProductDto>> GetTopSellingProductsAsync();
        Task<IEnumerable<MonthlySalesDto>> GetMonthlySalesAsync();
        Task<IEnumerable<RecentTransactionDto>> GetRecentTransactionsAsync();
    }
}