using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPINetCore.Migrations
{
    public partial class CreateTableDMTONGIAO2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMTONGIAO",
                columns: table => new
                {
                    MA = table.Column<string>(nullable: false),
                    TEN = table.Column<string>(nullable: false),
                    TRANGTHAI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMTONGIAO", x => x.MA);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMTONGIAO");
        }
    }
}
