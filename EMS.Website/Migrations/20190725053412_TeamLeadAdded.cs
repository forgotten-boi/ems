using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Website.Migrations
{
    public partial class TeamLeadAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamLeadId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamLeadId",
                table: "AspNetUsers",
                column: "TeamLeadId",
                unique: true,
                filter: "[TeamLeadId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeamLeadId",
                table: "AspNetUsers",
                column: "TeamLeadId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeamLeadId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamLeadId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamLeadId",
                table: "AspNetUsers");
        }
    }
}
