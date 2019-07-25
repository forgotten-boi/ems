using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Website.Migrations.ProjectDb
{
    public partial class EmployeeIdRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelInfo_Employee_EmployeeID",
                table: "TravelInfo");

            migrationBuilder.DropIndex(
                name: "IX_TravelInfo_EmployeeID",
                table: "TravelInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "TravelInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "TravelInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TravelInfo_EmployeeID",
                table: "TravelInfo",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelInfo_Employee_EmployeeID",
                table: "TravelInfo",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
