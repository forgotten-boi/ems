using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Website.Migrations.ProjectDb
{
    public partial class AddRelationExpensesAndMisc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TraveExpID",
                table: "MiscExpenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MiscExpenses_TraveExpID",
                table: "MiscExpenses",
                column: "TraveExpID");

            migrationBuilder.AddForeignKey(
                name: "FK_MiscExpenses_TravelExpenses_TraveExpID",
                table: "MiscExpenses",
                column: "TraveExpID",
                principalTable: "TravelExpenses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MiscExpenses_TravelExpenses_TraveExpID",
                table: "MiscExpenses");

            migrationBuilder.DropIndex(
                name: "IX_MiscExpenses_TraveExpID",
                table: "MiscExpenses");

            migrationBuilder.DropColumn(
                name: "TraveExpID",
                table: "MiscExpenses");
        }
    }
}
