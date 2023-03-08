using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnnecessaryRelationshipExExSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                table: "ExerciseSets");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSets_ExerciseId",
                table: "ExerciseSets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_ExerciseId",
                table: "ExerciseSets",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                table: "ExerciseSets",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
