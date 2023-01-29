using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseSetRepsOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ExerciseSets");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ExerciseSets");

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "ExerciseSets",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reps",
                table: "ExerciseSets");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ExerciseSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "ExerciseSets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
