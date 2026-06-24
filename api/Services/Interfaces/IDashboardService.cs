using api.DTOs.Dashboard;

namespace api.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}