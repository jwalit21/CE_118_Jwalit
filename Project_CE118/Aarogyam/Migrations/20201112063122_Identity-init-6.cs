using Microsoft.EntityFrameworkCore.Migrations;

namespace Aarogyam.Migrations
{
    public partial class Identityinit6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_HospitalId1",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_HospitalId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_HospitalId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HospitalId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "HospitalId1",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_HospitalId",
                table: "Tasks",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalId",
                table: "Patients",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_HospitalId",
                table: "Patients",
                column: "HospitalId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_HospitalId",
                table: "Tasks",
                column: "HospitalId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_HospitalId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_HospitalId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_HospitalId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HospitalId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalId1",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalId1",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_HospitalId1",
                table: "Tasks",
                column: "HospitalId1");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalId1",
                table: "Patients",
                column: "HospitalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_HospitalId1",
                table: "Patients",
                column: "HospitalId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_HospitalId1",
                table: "Tasks",
                column: "HospitalId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
