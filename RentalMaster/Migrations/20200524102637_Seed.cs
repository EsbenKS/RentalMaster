using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalMaster.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RentalItemModels",
                columns: new[] { "ID", "MakeID", "Name", "RentalItemMakeID" },
                values: new object[,]
                {
                    { 1, 0, "Auris", null },
                    { 2, 0, "Corolla", null },
                    { 3, 0, "MF 1500 | 19.5 - 32 HK", null },
                    { 4, 0, "MF 3700 AL", null },
                    { 5, 0, "MF 1700 | 38 - 46 HK", null }
                });

            migrationBuilder.InsertData(
                table: "RentalItemStatuses",
                columns: new[] { "ID", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, "Ready", 10 },
                    { 2, "Repair", 60 },
                    { 3, "Not Available", 20 },
                    { 4, "Pending Repair", 50 },
                    { 5, "Wrecked", 99 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RentalItemModels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalItemModels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalItemModels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentalItemModels",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RentalItemModels",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RentalItemStatuses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalItemStatuses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalItemStatuses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentalItemStatuses",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RentalItemStatuses",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
