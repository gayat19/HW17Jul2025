using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IDepartmentServices
    {
        public ICollection<GetDepartmnetsDTO>    GetDepartments { get; set; }
    }
}
