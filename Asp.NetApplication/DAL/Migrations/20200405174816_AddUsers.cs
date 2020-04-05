using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO dbo.Users (FirstName, LastName) 
                VALUES 
                    ('Mario', 'Mario'),
                    ('Luigi', 'Mario')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM dbo.Users WHERE FirstName = 'Mario' AND LastName = 'Mario'");
            migrationBuilder.Sql(@"DELETE FROM dbo.Users WHERE FirstName = 'Luigi' AND LastName = 'Mario'");
        }
    }
}
