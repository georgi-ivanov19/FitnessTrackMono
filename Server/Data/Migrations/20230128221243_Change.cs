﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_TrackedWorkouts_TrackedWorkoutId",
                table: "ExerciseSets");

            migrationBuilder.AlterColumn<int>(
                name: "TrackedWorkoutId",
                table: "ExerciseSets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_TrackedWorkouts_TrackedWorkoutId",
                table: "ExerciseSets",
                column: "TrackedWorkoutId",
                principalTable: "TrackedWorkouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_TrackedWorkouts_TrackedWorkoutId",
                table: "ExerciseSets");

            migrationBuilder.AlterColumn<int>(
                name: "TrackedWorkoutId",
                table: "ExerciseSets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_TrackedWorkouts_TrackedWorkoutId",
                table: "ExerciseSets",
                column: "TrackedWorkoutId",
                principalTable: "TrackedWorkouts",
                principalColumn: "Id");
        }
    }
}