using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddMoreGenreTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO dbo.GenreType (GenreTypeId, Name)
                VALUES (5, 'Shooter'),
                        (6, 'Simulation'),
                        (7, 'Battle Royale'),
                        (8, 'Rhythm'),
                        (9, 'Survival'),
                        (10, 'Real-time strategy'),
                        (11, 'Racing')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM dbo.GenreType WHERE GenreTypeID > 4");
        }
    }
}
