using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeedMembershipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO dbo.MembershipType (Id, SignUpFee, DurationInMonths, DiscountRate)
                VALUES (1, 0, 0, 0),
                        (2, 30, 1, 10),
                        (3, 90, 2, 15),
                        (4, 300, 12, 20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM dbo.MembershipType");
        }
    }
}
