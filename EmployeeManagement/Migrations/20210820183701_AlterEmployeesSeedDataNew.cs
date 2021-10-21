using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class AlterEmployeesSeedDataNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "NewTestName1");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "NewTestName2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "TestName1");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "TestName2");
        }
    }
}
