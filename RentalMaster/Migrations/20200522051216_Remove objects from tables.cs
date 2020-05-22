using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalMaster.Migrations
{
    public partial class Removeobjectsfromtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MakeModelOptions_RentalItemMakes_RentalItemMakeID",
                table: "MakeModelOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_MakeModelOptions_RentalItemModels_RentalItemModelID",
                table: "MakeModelOptions");

            migrationBuilder.DropIndex(
                name: "IX_MakeModelOptions_RentalItemMakeID",
                table: "MakeModelOptions");

            migrationBuilder.DropIndex(
                name: "IX_MakeModelOptions_RentalItemModelID",
                table: "MakeModelOptions");

            migrationBuilder.DropColumn(
                name: "RentalItemMakeID",
                table: "MakeModelOptions");

            migrationBuilder.DropColumn(
                name: "RentalItemModelID",
                table: "MakeModelOptions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalItemMakeID",
                table: "MakeModelOptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentalItemModelID",
                table: "MakeModelOptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MakeModelOptions_RentalItemMakeID",
                table: "MakeModelOptions",
                column: "RentalItemMakeID");

            migrationBuilder.CreateIndex(
                name: "IX_MakeModelOptions_RentalItemModelID",
                table: "MakeModelOptions",
                column: "RentalItemModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_MakeModelOptions_RentalItemMakes_RentalItemMakeID",
                table: "MakeModelOptions",
                column: "RentalItemMakeID",
                principalTable: "RentalItemMakes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MakeModelOptions_RentalItemModels_RentalItemModelID",
                table: "MakeModelOptions",
                column: "RentalItemModelID",
                principalTable: "RentalItemModels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
