namespace api.DTOs.Dashboard
{
    public class RecentTransactionDto
    {
        public string ProductName { get; set; }

        public string EmployeeName { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }
    }
}