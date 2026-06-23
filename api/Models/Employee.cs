namespace api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}