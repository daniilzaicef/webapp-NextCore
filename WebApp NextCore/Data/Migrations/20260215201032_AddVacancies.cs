using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_NextCore.Migrations
{
    /// <inheritdoc />
    public partial class AddVacancies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Vacancy");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vacancy");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Vacancy",
                newName: "Title");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Vacancy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Vacancy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Vacancy");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Vacancy");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Vacancy",
                newName: "Position");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Vacancy",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vacancy",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
