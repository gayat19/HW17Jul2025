namespace FirstAPI.Models
{
    public class DepartmnetStatusMaster
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
