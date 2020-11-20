using Microsoft.EntityFrameworkCore.Migrations;

namespace Aarogyam.Migrations
{
    public partial class Identityinit5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenHospitals_AspNetUsers_HospitalId1",
                table: "CitizenHospitals");

            migrationBuilder.DropIndex(
                name: "IX_CitizenHospitals_HospitalId1",
                table: "CitizenHospitals");

            migrationBuilder.DropColumn(
                name: "HospitalId1",
                table: "CitizenHospitals");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "CitizenHospitals",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenHospitals_HospitalId",
                table: "CitizenHospitals",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenHospitals_AspNetUsers_HospitalId",
                table: "CitizenHospitals",
                column: "HospitalId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenHospitals_AspNetUsers_HospitalId",
                table: "CitizenHospitals");

            migrationBuilder.DropIndex(
                name: "IX_CitizenHospitals_HospitalId",
                table: "CitizenHospitals");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "CitizenHospitals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalId1",
                table: "CitizenHospitals",
                type: "nvarchar(450)",
                nullable: true);

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
        }
    }
}
