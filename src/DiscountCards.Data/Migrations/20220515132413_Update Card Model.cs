using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountCards.Data.Migrations
{
    public partial class UpdateCardModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "standart",
                table: "cards",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "standart",
                table: "cards");
        }
    }
}
