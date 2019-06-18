using Microsoft.EntityFrameworkCore.Migrations;

namespace DataApp.Migrations
{
    public partial class CompleteOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_ContactLocations_LocationId",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_ContactDetails_ContactId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ContactId",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactLocations",
                table: "ContactLocations");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "ContactLocations",
                newName: "ContactLocation");

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                table: "ContactDetails",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactLocation",
                table: "ContactLocation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_SupplierId",
                table: "ContactDetails",
                column: "SupplierId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_ContactLocation_LocationId",
                table: "ContactDetails",
                column: "LocationId",
                principalTable: "ContactLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Suppliers_SupplierId",
                table: "ContactDetails",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_ContactLocation_LocationId",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Suppliers_SupplierId",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_SupplierId",
                table: "ContactDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactLocation",
                table: "ContactLocation");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ContactDetails");

            migrationBuilder.RenameTable(
                name: "ContactLocation",
                newName: "ContactLocations");

            migrationBuilder.AddColumn<long>(
                name: "ContactId",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactLocations",
                table: "ContactLocations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ContactId",
                table: "Suppliers",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_ContactLocations_LocationId",
                table: "ContactDetails",
                column: "LocationId",
                principalTable: "ContactLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_ContactDetails_ContactId",
                table: "Suppliers",
                column: "ContactId",
                principalTable: "ContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
