using Microsoft.EntityFrameworkCore.Migrations;

namespace CongratulationAPI.Migrations.Migrations
{
    public partial class Delete_status_from_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStatus",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
