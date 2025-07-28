using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Contexts
{
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().HasKey(e => e.Id).HasName("PK_Employee_Id");
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)//navigation object
                .WithMany(d => d.Employees)//navigation object
                .HasForeignKey(e => e.DepartmentId)
                .HasConstraintName("FK_Depatment_Employee")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>().HasKey(d => d.Id).HasName("PK_Department_Id");

            modelBuilder.Entity<Salary>().HasKey(s => s.SerialNumber).HasName("PK_Salary");

            modelBuilder.Entity<EmployeeSalary>()
                .HasOne(es => es.Salary)
                .WithMany(s=>s.EmployeeSalaries)
                .HasForeignKey(es => es.SalaryId)
                .HasConstraintName("FK_EmployeeSalary_Salary")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeSalary>()
               .HasOne(es => es.Employee)
               .WithMany(e => e.Salaries)
               .HasForeignKey(es => es.EmployeeId)
               .HasConstraintName("FK_EmployeeSalary_Employee")
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeSalary>().HasKey(es => es.SNo).HasName("PK_EMployeeSalary_ID");

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 101, Name = "HR" },
                new Department { Id = 102, Name = "Admin" }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Ramu", Email = "ramu@dubakkur.com", PhoneNumber = "9876543210", DepartmentId = 101 }
                );
        }

    }
}
