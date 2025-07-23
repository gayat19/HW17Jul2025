using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Models
{
    public class Employee : IEquatable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public Department Department { get; set; } = new Department();

        public Employee()
        {

        }

        public Employee(string name, DateTime dateOfBirth, string email, string phoneNumber, string image)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Image = image;
        }

        public Employee(int id, string name, DateTime dateOfBirth, string email, string phoneNumber, string image)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Image = image;
        }
        public Employee(int id, string name, DateTime dateOfBirth, string email, string phoneNumber, string image,int department_Id)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Image = image;
            Department.Id = department_Id;
        }
        public override string ToString()
        {
            return $"Employee Id : {Id}\nName : {Name}\nDateOfBirth : {DateOfBirth}\nEmail : {Email}\nPhone Number : {PhoneNumber}\nDeparmnet Details : {Department}";
        }

        public bool Equals(Employee? other)
        {
            return this.Id == other?.Id && this.Name == other?.Name;
        }

        public static bool operator==(Employee e1, Employee e2)
        {
            return e1.Id == e2.Id;
        }
        public static bool operator !=(Employee e1, Employee e2)
        {
            return e1.Id != e2.Id;
        }
    }
}
