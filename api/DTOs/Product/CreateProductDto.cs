using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Product
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Size { get; set; } = string.Empty;

        [Required]
        public string Color { get; set; } = string.Empty;

        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        [Range(0, 5000)]
        public int Quantity { get; set; }

        [Range(0, 500)]
        public int MinStockLevel { get; set; }
    }
}