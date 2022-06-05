using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountCards.Data.Migrations
{
    public partial class RenameLongtitudetoLongitudeinShopLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "longtitude",
                table: "shop_locations",
                newName: "request_longitude");

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "shop_locations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "request_latitude",
                table: "shop_locations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "longitude",
                table: "shop_locations");

            migrationBuilder.DropColumn(
                name: "request_latitude",
                table: "shop_locations");

            migrationBuilder.RenameColumn(
                name: "request_longitude",
                table: "shop_locations",
                newName: "longtitude");
        }
    }
}
