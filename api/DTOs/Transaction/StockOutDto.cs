namespace api.DTOs.Transaction
{
    public class StockOutDto
    {
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public int Quantity { get; set; }
    }
}