using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPINetCore.Migrations
{
    public partial class AddNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMDANTOC",
                columns: table => new
                {
                    MA = table.Column<string>(nullable: false),
                    TEN_DANTOC = table.Column<string>(nullable: false),
                    TEN_KHAC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMDANTOC", x => x.MA);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMDANTOC");
        }
    }
}
