using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMK.Migrations
{
    /// <inheritdoc />
    public partial class ReportOneToOneAdmission111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Admissions_AdmissionId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_MedicalReports_AdmissionId",
                table: "MedicalReports");

            migrationBuilder.DropColumn(
                name: "AdmissionId",
                table: "MedicalReports");

            migrationBuilder.AddColumn<int>(
                name: "MedicalReportId",
                table: "Admissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_MedicalReports_MedicalReportId",
                table: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_MedicalReportId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "MedicalReportId",
                table: "Admissions");

            migrationBuilder.AddColumn<int>(
                name: "AdmissionId",
                table: "MedicalReports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_AdmissionId",
                table: "MedicalReports",
                column: "AdmissionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Admissions_AdmissionId",
                table: "MedicalReports",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
