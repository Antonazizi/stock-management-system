namespace api.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public Product Product { get; set; }
        public Employee Employee { get; set; }
    }
}