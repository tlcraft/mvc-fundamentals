using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddGenreTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO dbo.GenreType (GenreTypeId, Name)
                VALUES (1, 'Action'),
                        (2, 'Platform'),
                        (3, 'Role-playing game'),
                        (4, 'Fighting')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM dbo.GenreType");
        }
    }
}
