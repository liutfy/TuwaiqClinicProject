using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROJECT1.Migrations
{
    /// <inheritdoc />
    public partial class patientanddoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocAndPat",
                columns: table => new
                {
                    Doctorsid = table.Column<int>(type: "int", nullable: false),
                    PatientsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocAndPat", x => new { x.Doctorsid, x.PatientsID });
                    table.ForeignKey(
                        name: "FK_DocAndPat_Doctors_Doctorsid",
                        column: x => x.Doctorsid,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocAndPat_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocAndPat_PatientsID",
                table: "DocAndPat",
                column: "PatientsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocAndPat");
        }
    }
}
