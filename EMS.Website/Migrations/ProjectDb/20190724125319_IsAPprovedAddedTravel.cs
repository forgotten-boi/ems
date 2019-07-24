using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Website.Migrations.ProjectDb
{
    public partial class IsAPprovedAddedTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "TravelInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecieptDoc",
                table: "TravelInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "TravelInfo");

            migrationBuilder.DropColumn(
                name: "RecieptDoc",
                table: "TravelInfo");
        }
    }
}
