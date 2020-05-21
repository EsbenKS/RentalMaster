using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalMaster.Migrations
{
    public partial class Initial122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalItemMakes_RentalItemCategories_RentalItemCategoryID",
                table: "RentalItemMakes");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalItems_RentalItemCategories_RentalItemCategoryID",
                table: "RentalItems");

            migrationBuilder.DropTable(
                name: "RentalItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_RentalItems_RentalItemCategoryID",
                table: "RentalItems");

            migrationBuilder.DropIndex(
                name: "IX_RentalItemMakes_RentalItemCategoryID",
                table: "RentalItemMakes");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "RentalItems");

            migrationBuilder.DropColumn(
                name: "RentalItemCategoryID",
                table: "RentalItems");

            migrationBuilder.DropColumn(
                name: "RentalItemCategoryID",
                table: "RentalItemMakes");

            migrationBuilder.AddColumn<int>(
                name: "MakeID",
                table: "RentalItemModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MakeID",
                table: "RentalItemModels");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "RentalItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentalItemCategoryID",
                table: "RentalItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentalItemCategoryID",
                table: "RentalItemMakes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RentalItemCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalItemCategories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalItems_RentalItemCategoryID",
                table: "RentalItems",
                column: "RentalItemCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalItemMakes_RentalItemCategoryID",
                table: "RentalItemMakes",
                column: "RentalItemCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItemMakes_RentalItemCategories_RentalItemCategoryID",
                table: "RentalItemMakes",
                column: "RentalItemCategoryID",
                principalTable: "RentalItemCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItems_RentalItemCategories_RentalItemCategoryID",
                table: "RentalItems",
                column: "RentalItemCategoryID",
                principalTable: "RentalItemCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
