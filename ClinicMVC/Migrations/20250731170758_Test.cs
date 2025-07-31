using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicMVC.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_Patientid",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Patientid",
                table: "Appointments",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_Patientid",
                table: "Appointments",
                newName: "IX_Appointments_PatientID");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientID",
                table: "Appointments",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientID",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Appointments",
                newName: "Patientid");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                newName: "IX_Appointments_Patientid");

            migrationBuilder.AlterColumn<int>(
                name: "Patientid",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "id", "AppointmentDate", "DoctorID", "Patientid", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Scheduled" },
                    { 2, new DateTime(2025, 7, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Completed" },
                    { 3, new DateTime(2025, 8, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Scheduled" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_Patientid",
                table: "Appointments",
                column: "Patientid",
                principalTable: "Patients",
                principalColumn: "id");
        }
    }
}
