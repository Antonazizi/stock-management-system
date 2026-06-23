namespace api.DTOs.Transaction
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}