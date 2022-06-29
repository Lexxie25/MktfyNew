using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKTFY.Repositories.Migrations
{
    public partial class ListingParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Listings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Listings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Listings");
        }
    }
}
