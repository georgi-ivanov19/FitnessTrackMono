﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeFKEYExSet_ExIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseSets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseSets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
