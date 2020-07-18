using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRented = table.Column<DateTime>(nullable: false),
                    DateReturned = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    GameId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rentals_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_GameId",
                table: "Rentals",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");
        }
    }
}
