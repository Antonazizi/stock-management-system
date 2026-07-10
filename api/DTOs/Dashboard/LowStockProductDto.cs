namespace api.DTOs.Dashboard
{
    public class LowStockProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int MinStockLevel { get; set; }
    }
}