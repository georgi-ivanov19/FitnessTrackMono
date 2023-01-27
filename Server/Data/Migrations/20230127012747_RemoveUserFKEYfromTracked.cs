using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackMono.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserFKEYfromTracked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackedWorkouts_AspNetUsers_ApplicationUserId",
                table: "TrackedWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_TrackedWorkouts_ApplicationUserId",
                table: "TrackedWorkouts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TrackedWorkouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TrackedWorkouts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TrackedWorkouts_ApplicationUserId",
                table: "TrackedWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackedWorkouts_AspNetUsers_ApplicationUserId",
                table: "TrackedWorkouts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
