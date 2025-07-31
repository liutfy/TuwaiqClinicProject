using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "id", "AppointmentDate", "DoctorID", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, "Scheduled" },
                    { 2, new DateTime(2025, 7, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, "Completed" },
                    { 3, new DateTime(2025, 8, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, "Scheduled" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
