using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstAPI.Migrations
{
    /// <inheritdoc />
    public partial class Empoyee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmnetStatusMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmnetStatusMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatusMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatusMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SerialNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basic = table.Column<float>(type: "real", nullable: false),
                    HRA = table.Column<float>(type: "real", nullable: false),
                    DA = table.Column<float>(type: "real", nullable: false),
                    Deduction = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Status",
                        column: x => x.Status,
                        principalTable: "DepartmnetStatusMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depatment_Employee",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Status",
                        column: x => x.Status,
                        principalTable: "EmployeeStatusMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalaries",
                columns: table => new
                {
                    SNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SalaryId = table.Column<int>(type: "int", nullable: false),
                    CreditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherDeductions = table.Column<float>(type: "real", nullable: false),
                    OtherCredits = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMployeeSalary_ID", x => x.SNo);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Salary",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DepartmnetStatusMasters",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "In-Operation" },
                    { 2, "Deffered" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeStatusMaster",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "InActive" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 101, "HR", 1 },
                    { 102, "Admin", 2 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DepartmentId", "Email", "Image", "Name", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, "ramu@dubakkur.com", "", "Ramu", "9876543210", 1 },
                    { 2, new DateTime(2005, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, "somu@dubakkur.com", "", "Somu", "4321098765", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Status",
                table: "Departments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Status",
                table: "Employees",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaries_EmployeeId",
                table: "EmployeeSalaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaries_SalaryId",
                table: "EmployeeSalaries",
                column: "SalaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSalaries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmployeeStatusMaster");

            migrationBuilder.DropTable(
                name: "DepartmnetStatusMasters");
        }
    }
}
