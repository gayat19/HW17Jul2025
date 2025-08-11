using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.Models
{
    public class User
    {

        public string Username { get; set; }=string.Empty;
        public byte[] Password { get; set; }
        public byte[] HashKey { get; set; }
        public string Role { get; set; }=string.Empty ;
        public int EmployeeNumber { get; set; }

 
        public Employee? Employee { get; set; }
    }
}
