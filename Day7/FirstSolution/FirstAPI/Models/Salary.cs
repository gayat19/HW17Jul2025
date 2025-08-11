namespace FirstAPI.Models
{
    public class Salary
    {
        public int SerialNumber { get; set; }
        public float Basic { get; set; }
        public float HRA { get; set; }
        public float DA { get; set; }
        public float Deduction { get; set; }
        public ICollection<EmployeeSalary>? EmployeeSalaries { get; set; }
    }
}
