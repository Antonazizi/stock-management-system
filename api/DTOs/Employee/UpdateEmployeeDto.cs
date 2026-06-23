namespace api.DTOs.Employee
{
    public class UpdateEmployeeDto
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}