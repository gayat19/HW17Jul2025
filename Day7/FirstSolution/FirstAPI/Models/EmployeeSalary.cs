using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.Models
{
    public class EmployeeSalary
    {
        [Key]
        public int SNo { get; set; }
        public int EmployeeId { get; set; }
        public int SalaryId { get; set; }
        public DateTime CreditedDate { get; set; }
        public float OtherDeductions { get; set; }
        public float OtherCredits { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        [ForeignKey("SalaryId")]
        public Salary? Salary { get; set; }
    }
}
