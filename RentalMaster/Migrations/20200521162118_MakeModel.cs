using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalMaster.Migrations
{
    public partial class MakeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MakeModelOptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MakeID = table.Column<int>(nullable: false),
                    RentalItemMakeID = table.Column<int>(nullable: true),
                    ModelID = table.Column<int>(nullable: false),
                    RentalItemModelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeModelOptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MakeModelOptions_RentalItemMakes_RentalItemMakeID",
                        column: x => x.RentalItemMakeID,
                        principalTable: "RentalItemMakes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MakeModelOptions_RentalItemModels_RentalItemModelID",
                        column: x => x.RentalItemModelID,
                        principalTable: "RentalItemModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MakeModelOptions_RentalItemMakeID",
                table: "MakeModelOptions",
                column: "RentalItemMakeID");

            migrationBuilder.CreateIndex(
                name: "IX_MakeModelOptions_RentalItemModelID",
                table: "MakeModelOptions",
                column: "RentalItemModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MakeModelOptions");
        }
    }
}
