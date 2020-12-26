using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace WebAPINetCore.Migrations
{
    public partial class DMUANHEDMHOCVAN1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMHOCVAN",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TEN = table.Column<string>(nullable: false),
                    MOTA = table.Column<string>(nullable: true),
                    THUTU = table.Column<int>(nullable: false),
                    TRANGTHAI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMHOCVAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DMQUANHE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    QUANHE = table.Column<string>(nullable: false),
                    GHICHU = table.Column<string>(nullable: true),
                    THUTU = table.Column<int>(nullable: false),
                    TRANGTHAI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMQUANHE", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMHOCVAN");

            migrationBuilder.DropTable(
                name: "DMQUANHE");
        }
    }
}
