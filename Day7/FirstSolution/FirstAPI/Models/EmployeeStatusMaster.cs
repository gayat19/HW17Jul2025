namespace FirstAPI.Models
{
    public class EmployeeStatusMaster
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
