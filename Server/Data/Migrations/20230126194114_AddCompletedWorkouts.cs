using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletedWorkouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompletedWorkoutId",
                table: "ExerciseSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompletedWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentWorkoutId = table.Column<int>(type: "int", nullable: false),
                    TotalVolume = table.Column<double>(type: "float", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompletedWorkouts_Workouts_ParentWorkoutId",
                        column: x => x.ParentWorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_CompletedWorkoutId",
                table: "ExerciseSets",
                column: "CompletedWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkouts_ApplicationUserId",
                table: "CompletedWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkouts_ParentWorkoutId",
                table: "CompletedWorkouts",
                column: "ParentWorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_CompletedWorkouts_CompletedWorkoutId",
                table: "ExerciseSets",
                column: "CompletedWorkoutId",
                principalTable: "CompletedWorkouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_CompletedWorkouts_CompletedWorkoutId",
                table: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "CompletedWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSets_CompletedWorkoutId",
                table: "ExerciseSets");

            migrationBuilder.DropColumn(
                name: "CompletedWorkoutId",
                table: "ExerciseSets");
        }
    }
}
