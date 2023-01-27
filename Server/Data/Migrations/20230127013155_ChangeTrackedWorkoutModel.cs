using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTrackedWorkoutModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackedWorkouts_Workouts_ParentWorkoutId",
                table: "TrackedWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_TrackedWorkouts_ParentWorkoutId",
                table: "TrackedWorkouts");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "TrackedWorkouts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackedWorkouts_WorkoutId",
                table: "TrackedWorkouts",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackedWorkouts_Workouts_WorkoutId",
                table: "TrackedWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackedWorkouts_Workouts_WorkoutId",
                table: "TrackedWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_TrackedWorkouts_WorkoutId",
                table: "TrackedWorkouts");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "TrackedWorkouts");

            migrationBuilder.CreateIndex(
                name: "IX_TrackedWorkouts_ParentWorkoutId",
                table: "TrackedWorkouts",
                column: "ParentWorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackedWorkouts_Workouts_ParentWorkoutId",
                table: "TrackedWorkouts",
                column: "ParentWorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
