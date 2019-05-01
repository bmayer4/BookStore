using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.API.Migrations
{
    public partial class bookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Books");
        }
    }
}
