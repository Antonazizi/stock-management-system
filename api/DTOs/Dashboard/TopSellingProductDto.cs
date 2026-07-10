namespace api.DTOs.Dashboard
{
    public class TopSellingProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int TotalSold { get; set; }
    }
}