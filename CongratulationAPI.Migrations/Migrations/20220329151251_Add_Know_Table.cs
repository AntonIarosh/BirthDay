using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongratulationAPI.Migrations.Migrations
{
    public partial class Add_Know_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthDay_Users",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Know",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    FromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Know", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Cnows",
                        column: x => x.FromUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Know_FromUserId",
                table: "Know",
                column: "FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthDay_Users",
                table: "User",
                column: "BirthDayId",
                principalTable: "BirthDay",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthDay_Users",
                table: "User");

            migrationBuilder.DropTable(
                name: "Know");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthDay_Users",
                table: "User",
                column: "BirthDayId",
                principalTable: "BirthDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
