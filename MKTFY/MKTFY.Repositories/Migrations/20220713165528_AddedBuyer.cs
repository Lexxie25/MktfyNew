using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKTFY.Repositories.Migrations
{
    public partial class AddedBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "Listings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Listings");
        }
    }
}
