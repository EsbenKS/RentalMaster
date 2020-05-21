using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalMaster.Migrations
{
    public partial class RentalStatusadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "RentalItems");

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "RentalItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RentalItemStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalItemStatuses", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalItems_RentalItemStatuses_StatusID",
                table: "RentalItems");

            migrationBuilder.DropTable(
                name: "RentalItemStatuses");

            migrationBuilder.DropIndex(
                name: "IX_RentalItems_StatusID",
                table: "RentalItems");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "RentalItems");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RentalItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
