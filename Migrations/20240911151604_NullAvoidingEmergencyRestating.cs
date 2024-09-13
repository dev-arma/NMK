﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMK.Migrations
{
    /// <inheritdoc />
    public partial class NullAvoidingEmergencyRestating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Admissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Emergency",
                table: "Admissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "Emergency",
                table: "Admissions");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Admissions",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
