using Microsoft.EntityFrameworkCore.Migrations;

namespace Aarogyam.Migrations
{
    public partial class Identityinit4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenHospitals_AspNetUsers_applicationUserId",
                table: "CitizenHospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_applicationUserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_applicationUserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_CitizenHospitals_applicationUserId",
                table: "CitizenHospitals");

            migrationBuilder.DropColumn(
                name: "CitizenUsername",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "CitizenHospitals");

            migrationBuilder.AddColumn<string>(
                name: "HospitalId1",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CitizenId",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HospitalId1",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalId1",
                table: "CitizenHospitals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_HospitalId1",
                table: "Tasks",
                column: "HospitalId1");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalId1",
                table: "Patients",
                column: "HospitalId1");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenHospitals_HospitalId1",
                table: "CitizenHospitals",
                column: "HospitalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenHospitals_AspNetUsers_HospitalId1",
                table: "CitizenHospitals",
                column: "HospitalId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenHospitals_AspNetUsers_HospitalId1",
                table: "CitizenHospitals");

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

            migrationBuilder.DropIndex(
                name: "IX_CitizenHospitals_HospitalId1",
                table: "CitizenHospitals");

            migrationBuilder.DropColumn(
                name: "HospitalId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CitizenId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalId1",
                table: "CitizenHospitals");

            migrationBuilder.AddColumn<int>(
                name: "CitizenUsername",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "CitizenHospitals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_applicationUserId",
                table: "Patients",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenHospitals_applicationUserId",
                table: "CitizenHospitals",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenHospitals_AspNetUsers_applicationUserId",
                table: "CitizenHospitals",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_applicationUserId",
                table: "Patients",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
