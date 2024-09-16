using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NMK.Migrations
{
    /// <inheritdoc />
    public partial class DateCreatedDateModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Patients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Doctors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Admissions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Admissions",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Admissions");
        }
    }
}
