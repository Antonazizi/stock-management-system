using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var data = await _dashboardService.GetDashboardAsync();
            return Ok(data);
        }

        [HttpGet("low-stock-products")]
        public async Task<IActionResult> GetLowStockProducts()
        {
            var result = await _dashboardService.GetLowStockProductsAsync();

            return Ok(result);
        }

        [HttpGet("top-selling-products")]
        public async Task<IActionResult> GetTopSellingProducts()
        {
            var result = await _dashboardService.GetTopSellingProductsAsync();

            return Ok(result);
        }

        [HttpGet("monthly-sales")]
        public async Task<IActionResult> GetMonthlySales()
        {
            var result = await _dashboardService.GetMonthlySalesAsync();

            return Ok(result);
        }

        [HttpGet("recent-transactions")]
        public async Task<IActionResult> GetRecentTransactions()
        {
            var result = await _dashboardService.GetRecentTransactionsAsync();

            return Ok(result);
        }
    }
}