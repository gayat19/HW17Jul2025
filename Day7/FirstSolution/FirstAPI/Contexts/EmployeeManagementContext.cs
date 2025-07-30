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

        public DbSet<EmployeeStatusMaster> EmployeeStatusMaster { get; set; }
        public DbSet<DepartmnetStatusMaster> DepartmnetStatusMasters { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u=>u.Username);
            modelBuilder.Entity<User>().HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<User>(u => u.EmployeeNumber)
                .HasConstraintName("FK_USerEmployee");

            modelBuilder.Entity<Employee>().HasKey(e => e.Id).HasName("PK_Employee_Id");
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)//navigation object
                .WithMany(d => d.Employees)//navigation object
                .HasForeignKey(e => e.DepartmentId)
                .HasConstraintName("FK_Depatment_Employee")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>().HasOne(e => e.EmployeeStatus)
                .WithMany(es => es.Employees)
                .HasForeignKey(e => e.Status)
                .HasConstraintName("FK_Employee_Status")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>().HasKey(d => d.Id).HasName("PK_Department_Id");
            modelBuilder.Entity<Department>().HasOne(e => e.DepartmnetStatus)
               .WithMany(es => es.Departments)
               .HasForeignKey(e => e.Status)
               .HasConstraintName("FK_Department_Status")
               .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<EmployeeStatusMaster>().HasData(
                new EmployeeStatusMaster { Id=1,Status="Active"},
                new EmployeeStatusMaster { Id = 2, Status = "InActive" }
                );
            modelBuilder.Entity<DepartmnetStatusMaster>().HasData(
            new DepartmnetStatusMaster { Id = 1, Status = "In-Operation" },
               new DepartmnetStatusMaster { Id = 2, Status = "Deffered" }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 101, Name = "HR",Status=1 },
                new Department { Id = 102, Name = "Admin", Status = 2 }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Ramu",DateOfBirth=new DateTime(2000,2,4) , Email = "ramu@dubakkur.com", PhoneNumber = "9876543210", DepartmentId = 101,Status=1 },
                 new Employee { Id = 2, Name = "Somu", DateOfBirth = new DateTime(2005, 8, 14), Email = "somu@dubakkur.com", PhoneNumber = "4321098765", DepartmentId = 101, Status = 1 }
                );
        }

    }
}
