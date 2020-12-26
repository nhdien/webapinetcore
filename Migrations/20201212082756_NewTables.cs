using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPINetCore.Migrations
{
    public partial class NewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMHuyen",
                columns: table => new
                {
                    Ma = table.Column<string>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    Cap = table.Column<int>(nullable: false),
                    NSD = table.Column<string>(nullable: true),
                    NgayNhap = table.Column<DateTime>(nullable: false),
                    MaTinh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMHuyen", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "DMPhuongXa",
                columns: table => new
                {
                    Ma = table.Column<string>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    Cap = table.Column<int>(nullable: false),
                    NSD = table.Column<string>(nullable: true),
                    NgayNhap = table.Column<DateTime>(nullable: false),
                    MaTinh = table.Column<string>(nullable: true),
                    MaHuyen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMPhuongXa", x => x.Ma);
                });

            migrationBuilder.CreateTable(
                name: "DMTinh",
                columns: table => new
                {
                    Ma = table.Column<string>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    Cap = table.Column<int>(nullable: false),
                    NSD = table.Column<string>(nullable: true),
                    NgayNhap = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMTinh", x => x.Ma);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMHuyen");

            migrationBuilder.DropTable(
                name: "DMPhuongXa");

            migrationBuilder.DropTable(
                name: "DMTinh");
        }
    }
}
