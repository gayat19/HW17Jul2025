using FirstAPI.Models.DTOs;
using System.Collections.ObjectModel;

namespace FirstAPI.Interfaces
{
    public interface IEmployeeDashboardService
    {
        public Task<PaginatedEmployeeResponseDTO> SeachEmployees(EmployeeSearchRequestDto request);
    }
}
