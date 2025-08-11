using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IDepartmentServices
    {
        public Task<ICollection<GetDepartmnetsDTO>>    GetDepartments { get; set; }
    }
}
