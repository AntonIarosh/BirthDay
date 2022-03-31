using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongratulationAPI.Migrations.Migrations
{
    public partial class add_Congratulation_User_From_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Congratulation_User_FromUserId",
                table: "Congratulation");

            migrationBuilder.AlterColumn<Guid>(
                name: "FromUserId",
                table: "Congratulation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Congratulations_From_",
                table: "Congratulation",
                column: "FromUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Congratulations_From_",
                table: "Congratulation");

            migrationBuilder.AlterColumn<Guid>(
                name: "FromUserId",
                table: "Congratulation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Congratulation_User_FromUserId",
                table: "Congratulation",
                column: "FromUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
