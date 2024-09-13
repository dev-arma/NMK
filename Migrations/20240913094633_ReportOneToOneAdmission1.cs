using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMK.Migrations
{
    /// <inheritdoc />
    public partial class ReportOneToOneAdmission1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_MedicalReports_ReportID",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Patients_PatientId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_MedicalReports_DoctorId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_MedicalReports_PatientId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_ReportID",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "MedicalReports");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "MedicalReports");

            migrationBuilder.DropColumn(
                name: "ReportID",
                table: "Admissions");

            migrationBuilder.AddColumn<int>(
                name: "AdmissionId",
                table: "MedicalReports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicalReportId",
                table: "Admissions",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "MedicalReportId",
                table: "Admissions");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "MedicalReports",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "MedicalReports",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportID",
                table: "Admissions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_DoctorId",
                table: "MedicalReports",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_PatientId",
                table: "MedicalReports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_ReportID",
                table: "Admissions",
                column: "ReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_MedicalReports_ReportID",
                table: "Admissions",
                column: "ReportID",
                principalTable: "MedicalReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Patients_PatientId",
                table: "MedicalReports",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
