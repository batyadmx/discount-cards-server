using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountCards.Data.Migrations
{
    public partial class UpdateCardModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_source",
                table: "cards",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "cards",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_source",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "name",
                table: "cards");
        }
    }
}
