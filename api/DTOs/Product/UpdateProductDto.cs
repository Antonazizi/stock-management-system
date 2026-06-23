namespace api.DTOs.Product
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int MinStockLevel { get; set; }
    }
}