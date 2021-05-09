using Microsoft.EntityFrameworkCore.Migrations;

namespace Kartvizit.Migrations
{
    public partial class firmalar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "firma",
                columns: table => new
                {
                    firmaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    shortDesc = table.Column<string>(maxLength: 200, nullable: true),
                    phone = table.Column<string>(maxLength: 20, nullable: true),
                    address = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firma", x => x.firmaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "firma");
        }
    }
}
