using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_NextCore.Migrations
{
    /// <inheritdoc />
    public partial class AddProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Services' 
               AND COLUMN_NAME = 'ShortDescription')
    BEGIN
        ALTER TABLE [Services] DROP COLUMN [ShortDescription];
    END
");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Solution",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Task",
                table: "Projects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CompletionDate",
                table: "Projects",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "Task");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Projects",
                newName: "CompletionDate");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Solution",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
