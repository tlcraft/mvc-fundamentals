using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MembershipTypeId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignUpFee = table.Column<short>(nullable: false),
                    DurationInMonths = table.Column<byte>(nullable: false),
                    DiscountRate = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MembershipTypeId",
                table: "Users",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MembershipType_MembershipTypeId",
                table: "Users",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(@"
                INSERT INTO dbo.MembershipType 
                    (SignUpFee, DurationInMonths, DiscountRate)
                VALUES
                    (0, 0, 0),
                    (30, 1, 10),
                    (90, 3, 15),
                    (300, 12, 20)");

            migrationBuilder.Sql(@"
                UPDATE dbo.Users 
                SET MembershipTypeId = 1
                WHERE MembershipTypeId IS NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MembershipType_MembershipTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_Users_MembershipTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Users");
        }
    }
}
