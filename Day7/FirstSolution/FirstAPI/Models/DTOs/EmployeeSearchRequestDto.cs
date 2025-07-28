namespace FirstAPI.Models.DTOs
{
    public class SearchRange<T>
    {
        public T MinValue { get; set; }
        public T MaxValue { get; set; }
    }


    public class EmployeeSearchRequestDto
    {
        public string? Name { get; set; }
        public SearchRange<DateTime>? DateOfBirth { get; set; }

        public List<int>? Departments { get; set; }

        public string? PhoneNumber { get; set; }

        //1- By ID asc, -1 - By ID desc, 2- By name asc, -2 - by name desc, 3- By department id asc, -3 by department id desc

        public int Sort { get; set; }

    }
}
