using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InsertMembershipNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(UpdateMemebershipTypeName("Free", 1));
            migrationBuilder.Sql(UpdateMemebershipTypeName("Monthly", 2));
            migrationBuilder.Sql(UpdateMemebershipTypeName("Quarterly", 3));
            migrationBuilder.Sql(UpdateMemebershipTypeName("Annually", 4));
        }

        private string UpdateMemebershipTypeName(string name, int id)
        {
            return $"UPDATE dbo.MembershipType SET Name = '{name}' WHERE MembershipTypeId = {id}";
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE dbo.MembershipType SET Name = NULL");
        }
    }
}
