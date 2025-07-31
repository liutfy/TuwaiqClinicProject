using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicMVC.Migrations
{
    /// <inheritdoc />
    public partial class PatientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Patientid",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 1,
                column: "Patientid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 2,
                column: "Patientid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 3,
                column: "Patientid",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Patientid",
                table: "Appointments",
                column: "Patientid");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_Patientid",
                table: "Appointments",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_Patientid",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Patientid",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Patientid",
                table: "Appointments");
        }
    }
}
