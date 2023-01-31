using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixWorkoutTrackedFkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackedWorkouts_Workouts_WorkoutId",
                table: "TrackedWorkouts");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "TrackedWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackedWorkouts_Workouts_WorkoutId",
                table: "TrackedWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackedWorkouts_Workouts_WorkoutId",
                table: "TrackedWorkouts");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "TrackedWorkouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackedWorkouts_Workouts_WorkoutId",
                table: "TrackedWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }
    }
}
