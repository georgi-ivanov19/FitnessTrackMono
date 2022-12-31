using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Measurements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Measurements",
                newName: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Measurements",
                newName: "Name");
        }
    }
}
