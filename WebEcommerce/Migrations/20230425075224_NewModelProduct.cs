using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEcommerce.Migrations
{
    public partial class NewModelProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Products",
                newName: "Specifications");

            migrationBuilder.AddColumn<string>(
                name: "Introduce",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Introduce",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Specifications",
                table: "Products",
                newName: "Detail");
        }
    }
}
