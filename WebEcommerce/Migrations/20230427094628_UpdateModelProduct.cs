using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEcommerce.Migrations
{
    public partial class UpdateModelProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specifications",
                table: "Products",
                newName: "Weight");

            migrationBuilder.AddColumn<string>(
                name: "WarrantlyPeirod",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarrantlyPeirod",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Products",
                newName: "Specifications");
        }
    }
}
