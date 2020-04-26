using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO dbo.Games (Name, ReleaseDate) 
                VALUES 
                    ('Animal Crossing: New Horizons', '20200320'),
                    ('Doom Eternal', '20200320')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM dbo.Games WHERE Name IN ('Animal Crossing: New Horizons', 'Doom Eternal')");
        }
    }
}
