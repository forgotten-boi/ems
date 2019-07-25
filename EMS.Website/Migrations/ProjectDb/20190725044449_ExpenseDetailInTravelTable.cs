using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Website.Migrations.ProjectDb
{
    public partial class ExpenseDetailInTravelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "TravelInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "TravelInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "TravelInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFName",
                table: "TravelInfo",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeLName",
                table: "TravelInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "TravelInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                table: "TravelInfo");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "TravelInfo");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "TravelInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeFName",
                table: "TravelInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeLName",
                table: "TravelInfo");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "TravelInfo");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "Employee",
                nullable: true);
        }
    }
}
