using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMK.Migrations
{
    /// <inheritdoc />
    public partial class ReportOneToOneAdmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Patients_PatientId",
                table: "MedicalReports");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "MedicalReports",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "MedicalReports",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ReportID",
                table: "Admissions",
                type: "INTEGER",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_Admissions_ReportID",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "ReportID",
                table: "Admissions");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "MedicalReports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "MedicalReports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Patients_PatientId",
                table: "MedicalReports",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
