using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace WebAPINetCore.Migrations
{
    public partial class NewTables20201226 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMCAPBAC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CAPBAC = table.Column<string>(nullable: false),
                    GHICHU = table.Column<string>(nullable: true),
                    THUTU = table.Column<int>(nullable: false),
                    TRANGTHAI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMCAPBAC", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DMDANHHIEU",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TEN = table.Column<string>(nullable: false),
                    GHICHU = table.Column<string>(nullable: true),
                    THUTU = table.Column<int>(nullable: false),
                    TRANGTHAI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMDANHHIEU", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DMHUANHUYCHUONG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TEN = table.Column<string>(nullable: false),
                    GHICHU = table.Column<string>(nullable: true),
                    THUTU = table.Column<int>(nullable: false),
                    TRANGTHAI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMHUANHUYCHUONG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DMLOAI_BANGKHEN",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TEN = table.Column<string>(nullable: false),
                    GHICHU = table.Column<string>(nullable: true),
                    THUTU = table.Column<int>(nullable: false),
                    TRANGTHAI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMLOAI_BANGKHEN", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMCAPBAC");

            migrationBuilder.DropTable(
                name: "DMDANHHIEU");

            migrationBuilder.DropTable(
                name: "DMHUANHUYCHUONG");

            migrationBuilder.DropTable(
                name: "DMLOAI_BANGKHEN");
        }
    }
}
