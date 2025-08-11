using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models.DTOs
{
    public class AddEmployeeRequestDTO 
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Name cannot be empty")]
        [MinLength(3,ErrorMessage ="Name should be min 3 chars long")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage ="Date of Birth cannot be empty")]
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
