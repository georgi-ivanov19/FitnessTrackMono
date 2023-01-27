using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrackedWorkouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackedWorkoutId",
                table: "ExerciseSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrackedWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentWorkoutId = table.Column<int>(type: "int", nullable: false),
                    TotalVolume = table.Column<double>(type: "float", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackedWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackedWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackedWorkouts_Workouts_ParentWorkoutId",
                        column: x => x.ParentWorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_TrackedWorkoutId",
                table: "ExerciseSets",
                column: "TrackedWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackedWorkouts_ApplicationUserId",
                table: "TrackedWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackedWorkouts_ParentWorkoutId",
                table: "TrackedWorkouts",
                column: "ParentWorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_TrackedWorkouts_TrackedWorkoutId",
                table: "ExerciseSets",
                column: "TrackedWorkoutId",
                principalTable: "TrackedWorkouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_TrackedWorkouts_TrackedWorkoutId",
                table: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "TrackedWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSets_TrackedWorkoutId",
                table: "ExerciseSets");

            migrationBuilder.DropColumn(
                name: "TrackedWorkoutId",
                table: "ExerciseSets");
        }
    }
}
