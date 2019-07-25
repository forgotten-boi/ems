using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Website.Migrations
{
    public partial class RelationShipAddedInDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamLeadId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamLeadId",
                table: "AspNetUsers",
                column: "TeamLeadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamLeadId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamLeadId",
                table: "AspNetUsers",
                column: "TeamLeadId",
                unique: true,
                filter: "[TeamLeadId] IS NOT NULL");
        }
    }
}
