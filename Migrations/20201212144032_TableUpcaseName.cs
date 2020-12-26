using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPINetCore.Migrations
{
    public partial class TableUpcaseName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMTinh",
                table: "DMTinh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DMPhuongXa",
                table: "DMPhuongXa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DMHuyen",
                table: "DMHuyen");

            migrationBuilder.RenameTable(
                name: "DMTinh",
                newName: "DMTINH");

            migrationBuilder.RenameTable(
                name: "DMPhuongXa",
                newName: "DMPHUONGXA");

            migrationBuilder.RenameTable(
                name: "DMHuyen",
                newName: "DMHUYEN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMTINH",
                table: "DMTINH",
                column: "MA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMPHUONGXA",
                table: "DMPHUONGXA",
                column: "MA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMHUYEN",
                table: "DMHUYEN",
                column: "MA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMTINH",
                table: "DMTINH");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DMPHUONGXA",
                table: "DMPHUONGXA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DMHUYEN",
                table: "DMHUYEN");

            migrationBuilder.RenameTable(
                name: "DMTINH",
                newName: "DMTinh");

            migrationBuilder.RenameTable(
                name: "DMPHUONGXA",
                newName: "DMPhuongXa");

            migrationBuilder.RenameTable(
                name: "DMHUYEN",
                newName: "DMHuyen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMTinh",
                table: "DMTinh",
                column: "MA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMPhuongXa",
                table: "DMPhuongXa",
                column: "MA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMHuyen",
                table: "DMHuyen",
                column: "MA");
        }
    }
}
