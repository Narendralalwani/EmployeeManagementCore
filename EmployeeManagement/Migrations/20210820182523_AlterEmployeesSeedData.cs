using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class AlterEmployeesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 1, 1, "test@gmail.com", "TestName1" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 2, 2, "test@gmail.com", "TestName2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 123, 1, "test@gmail.com", "TestName" });
        }
    }
}
