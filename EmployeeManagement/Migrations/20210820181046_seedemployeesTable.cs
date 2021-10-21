using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class seedemployeesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 123, 1, "test@gmail.com", "TestName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 123);
        }
    }
}
