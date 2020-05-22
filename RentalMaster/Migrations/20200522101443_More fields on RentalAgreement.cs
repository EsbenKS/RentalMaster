using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalMaster.Migrations
{
    public partial class MorefieldsonRentalAgreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RentalEndDate",
                table: "RentalAgreements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalReturnedDate",
                table: "RentalAgreements",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalStartDate",
                table: "RentalAgreements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalEndDate",
                table: "RentalAgreements");

            migrationBuilder.DropColumn(
                name: "RentalReturnedDate",
                table: "RentalAgreements");

            migrationBuilder.DropColumn(
                name: "RentalStartDate",
                table: "RentalAgreements");
        }
    }
}
