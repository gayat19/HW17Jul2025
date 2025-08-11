namespace FirstAPI.Models.DTOs
{
    public class EmployeeSerachResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public string Department_Name { get; set; } = string.Empty;


    }
}
