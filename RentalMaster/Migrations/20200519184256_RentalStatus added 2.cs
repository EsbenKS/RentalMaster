using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalMaster.Migrations
{
    public partial class RentalStatusadded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalItems_RentalItemStatuses_StatusID",
                table: "RentalItems");

            migrationBuilder.DropIndex(
                name: "IX_RentalItems_StatusID",
                table: "RentalItems");

            migrationBuilder.AddColumn<int>(
                name: "RentalItemStatusID",
                table: "RentalItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalItems_RentalItemStatusID",
                table: "RentalItems",
                column: "RentalItemStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItems_RentalItemStatuses_RentalItemStatusID",
                table: "RentalItems",
                column: "RentalItemStatusID",
                principalTable: "RentalItemStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalItems_RentalItemStatuses_RentalItemStatusID",
                table: "RentalItems");

            migrationBuilder.DropIndex(
                name: "IX_RentalItems_RentalItemStatusID",
                table: "RentalItems");

            migrationBuilder.DropColumn(
                name: "RentalItemStatusID",
                table: "RentalItems");

            migrationBuilder.CreateIndex(
                name: "IX_RentalItems_StatusID",
                table: "RentalItems",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItems_RentalItemStatuses_StatusID",
                table: "RentalItems",
                column: "StatusID",
                principalTable: "RentalItemStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
