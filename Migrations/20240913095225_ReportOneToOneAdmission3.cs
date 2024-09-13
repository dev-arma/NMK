using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMK.Migrations
{
    /// <inheritdoc />
    public partial class ReportOneToOneAdmission3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_MedicalReports_MedicalReportId",
                table: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_MedicalReports_AdmissionId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_MedicalReportId",
                table: "Admissions");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_AdmissionId",
                table: "MedicalReports",
                column: "AdmissionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalReports_AdmissionId",
                table: "MedicalReports");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_AdmissionId",
                table: "MedicalReports",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_MedicalReportId",
                table: "Admissions",
                column: "MedicalReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_MedicalReports_MedicalReportId",
                table: "Admissions",
                column: "MedicalReportId",
                principalTable: "MedicalReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
