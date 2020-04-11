using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "GenreTypeId",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GenreType",
                columns: table => new
                {
                    GenreTypeId = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreType", x => x.GenreTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreTypeId",
                table: "Games",
                column: "GenreTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GenreType_GenreTypeId",
                table: "Games",
                column: "GenreTypeId",
                principalTable: "GenreType",
                principalColumn: "GenreTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GenreType_GenreTypeId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GenreType");

            migrationBuilder.DropIndex(
                name: "IX_Games_GenreTypeId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GenreTypeId",
                table: "Games");
        }
    }
}
