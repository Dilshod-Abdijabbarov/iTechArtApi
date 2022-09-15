using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTechArtApi.Migrations
{
    public partial class Firtsmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Personid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Personid);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Petid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Petid);
                    table.ForeignKey(
                        name: "FK_Pets_People_Personid",
                        column: x => x.Personid,
                        principalTable: "People",
                        principalColumn: "Personid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_Personid",
                table: "Pets",
                column: "Personid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
