using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalMaster.Migrations
{
    public partial class Makestatusintointernallistinsteadofdatabasetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalItems_RentalItemStatuses_RentalItemStatusID",
                table: "RentalItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalItemStatuses",
                table: "RentalItemStatuses");

            migrationBuilder.RenameTable(
                name: "RentalItemStatuses",
                newName: "RentalItemStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalItemStatus",
                table: "RentalItemStatus",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItems_RentalItemStatus_RentalItemStatusID",
                table: "RentalItems",
                column: "RentalItemStatusID",
                principalTable: "RentalItemStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalItems_RentalItemStatus_RentalItemStatusID",
                table: "RentalItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalItemStatus",
                table: "RentalItemStatus");

            migrationBuilder.RenameTable(
                name: "RentalItemStatus",
                newName: "RentalItemStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalItemStatuses",
                table: "RentalItemStatuses",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItems_RentalItemStatuses_RentalItemStatusID",
                table: "RentalItems",
                column: "RentalItemStatusID",
                principalTable: "RentalItemStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
