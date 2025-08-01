namespace FirstAPI.Models.DTOs
{
    public class PaginatedEmployeeResponseDTO
    {
        public List<EmployeeSerachResponseDTO>? Employees { get; set; }
        public int? PageNumber { get; set; }
        public int? TotalNumberOfRecords { get; set; }
        public ErrorObjectDTO? Error { get; set; }
    }
}
