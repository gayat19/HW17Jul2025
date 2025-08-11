using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.Models
{
    public class EmployeeSalary
    {

        public int SNo { get; set; }
        public int EmployeeId { get; set; }
        public int SalaryId { get; set; }
        public DateTime CreditedDate { get; set; }
        public float OtherDeductions { get; set; }
        public float OtherCredits { get; set; }


        public Employee? Employee { get; set; }


        public Salary? Salary { get; set; }
    }
}
