namespace api.DTOs.Dashboard
{
    public class DashboardDto
    {
        public int TotalProducts { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalTransactions { get; set; }
        public int LowStockProducts { get; set; }
        public int OutOfStockProducts { get; set; }
        public decimal TotalSales { get; set; }
    }
}