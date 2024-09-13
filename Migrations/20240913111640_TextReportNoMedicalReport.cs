using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMK.Migrations
{
    /// <inheritdoc />
    public partial class TextReportNoMedicalReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_MedicalReports_MedicalReportId",
                table: "Admissions");

            migrationBuilder.DropTable(
                name: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_MedicalReportId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "MedicalReportId",
                table: "Admissions");

            migrationBuilder.AddColumn<string>(
                name: "ReportText",
                table: "Admissions",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportText",
                table: "Admissions");

            migrationBuilder.AddColumn<int>(
                name: "MedicalReportId",
                table: "Admissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MedicalReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfReport = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReportText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalReports", x => x.Id);
                });

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
