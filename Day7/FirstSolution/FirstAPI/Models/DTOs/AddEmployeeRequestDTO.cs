namespace FirstAPI.Models.DTOs
{
    public class AddEmployeeRequestDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int DepartmentId { get; set; }

        public int Status { get; set; }
        public Department? Department { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
