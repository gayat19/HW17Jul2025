using FirstAPI.Repositories;
using System.Collections.Generic;

namespace FirstAPI.Models.DTOs
{
    public class EmployeeAddResponseDTO
    {
        public ICollection<GetDepartmnetsDTO>? Departments { get; set; }
        public ICollection<EmployeeStatusDTO>? EmployeeStatuses { get; set; }
    }
}
