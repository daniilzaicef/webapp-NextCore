using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_NextCore.Migrations
{
    /// <inheritdoc />
    public partial class AddFullDescriptionToService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "Services");
        }
    }
}
