using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPINetCore.Migrations
{
    public partial class AlterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TRANGTHAI",
                table: "DMDANTOC",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TRANGTHAI",
                table: "DMDANTOC");
        }
    }
}
