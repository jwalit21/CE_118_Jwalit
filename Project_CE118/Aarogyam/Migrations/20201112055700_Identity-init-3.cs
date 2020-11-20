using Microsoft.EntityFrameworkCore.Migrations;

namespace Aarogyam.Migrations
{
    public partial class Identityinit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_applicationUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_applicationUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "Tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_applicationUserId",
                table: "Tasks",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_applicationUserId",
                table: "Tasks",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
