using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPINetCore.Migrations
{
    public partial class TableUpcaseFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ten",
                table: "DMTinh",
                newName: "TEN");

            migrationBuilder.RenameColumn(
                name: "NgayNhap",
                table: "DMTinh",
                newName: "NGAYNHAP");

            migrationBuilder.RenameColumn(
                name: "Cap",
                table: "DMTinh",
                newName: "CAP");

            migrationBuilder.RenameColumn(
                name: "Ma",
                table: "DMTinh",
                newName: "MA");

            migrationBuilder.RenameColumn(
                name: "Ten",
                table: "DMPhuongXa",
                newName: "TEN");

            migrationBuilder.RenameColumn(
                name: "NgayNhap",
                table: "DMPhuongXa",
                newName: "NGAYNHAP");

            migrationBuilder.RenameColumn(
                name: "MaTinh",
                table: "DMPhuongXa",
                newName: "MATINH");

            migrationBuilder.RenameColumn(
                name: "MaHuyen",
                table: "DMPhuongXa",
                newName: "MAHUYEN");

            migrationBuilder.RenameColumn(
                name: "Cap",
                table: "DMPhuongXa",
                newName: "CAP");

            migrationBuilder.RenameColumn(
                name: "Ma",
                table: "DMPhuongXa",
                newName: "MA");

            migrationBuilder.RenameColumn(
                name: "Ten",
                table: "DMHuyen",
                newName: "TEN");

            migrationBuilder.RenameColumn(
                name: "NgayNhap",
                table: "DMHuyen",
                newName: "NGAYNHAP");

            migrationBuilder.RenameColumn(
                name: "MaTinh",
                table: "DMHuyen",
                newName: "MATINH");

            migrationBuilder.RenameColumn(
                name: "Cap",
                table: "DMHuyen",
                newName: "CAP");

            migrationBuilder.RenameColumn(
                name: "Ma",
                table: "DMHuyen",
                newName: "MA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TEN",
                table: "DMTinh",
                newName: "Ten");

            migrationBuilder.RenameColumn(
                name: "NGAYNHAP",
                table: "DMTinh",
                newName: "NgayNhap");

            migrationBuilder.RenameColumn(
                name: "CAP",
                table: "DMTinh",
                newName: "Cap");

            migrationBuilder.RenameColumn(
                name: "MA",
                table: "DMTinh",
                newName: "Ma");

            migrationBuilder.RenameColumn(
                name: "TEN",
                table: "DMPhuongXa",
                newName: "Ten");

            migrationBuilder.RenameColumn(
                name: "NGAYNHAP",
                table: "DMPhuongXa",
                newName: "NgayNhap");

            migrationBuilder.RenameColumn(
                name: "MATINH",
                table: "DMPhuongXa",
                newName: "MaTinh");

            migrationBuilder.RenameColumn(
                name: "MAHUYEN",
                table: "DMPhuongXa",
                newName: "MaHuyen");

            migrationBuilder.RenameColumn(
                name: "CAP",
                table: "DMPhuongXa",
                newName: "Cap");

            migrationBuilder.RenameColumn(
                name: "MA",
                table: "DMPhuongXa",
                newName: "Ma");

            migrationBuilder.RenameColumn(
                name: "TEN",
                table: "DMHuyen",
                newName: "Ten");

            migrationBuilder.RenameColumn(
                name: "NGAYNHAP",
                table: "DMHuyen",
                newName: "NgayNhap");

            migrationBuilder.RenameColumn(
                name: "MATINH",
                table: "DMHuyen",
                newName: "MaTinh");

            migrationBuilder.RenameColumn(
                name: "CAP",
                table: "DMHuyen",
                newName: "Cap");

            migrationBuilder.RenameColumn(
                name: "MA",
                table: "DMHuyen",
                newName: "Ma");
        }
    }
}
