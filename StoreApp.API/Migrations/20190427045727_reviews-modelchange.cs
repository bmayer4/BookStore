using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.API.Migrations
{
    public partial class reviewsmodelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Rating",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
