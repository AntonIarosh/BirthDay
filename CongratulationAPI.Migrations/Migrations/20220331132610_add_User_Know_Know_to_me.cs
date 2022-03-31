using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongratulationAPI.Migrations.Migrations
{
    public partial class add_User_Know_Know_to_me : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KnowUserId",
                table: "Know",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Know_KnowUserId",
                table: "Know",
                column: "KnowUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Knows_",
                table: "Know",
                column: "KnowUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Knows_",
                table: "Know");

            migrationBuilder.DropIndex(
                name: "IX_Know_KnowUserId",
                table: "Know");

            migrationBuilder.DropColumn(
                name: "KnowUserId",
                table: "Know");
        }
    }
}
