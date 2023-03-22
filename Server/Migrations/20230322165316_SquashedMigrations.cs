using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessTrackMono.Server.Migrations
{
    /// <inheritdoc />
    public partial class SquashedMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "bit", nullable: false),
                    DataProtected = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCalories = table.Column<double>(type: "float", nullable: true),
                    Protein = table.Column<double>(type: "float", nullable: true),
                    Fats = table.Column<double>(type: "float", nullable: true),
                    Carbohydrates = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastCompleted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    DefaultNumberOfSets = table.Column<int>(type: "int", nullable: true),
                    TargetMuscle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackedWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalVolume = table.Column<double>(type: "float", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackedWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackedWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: true),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    IsWarmup = table.Column<bool>(type: "bit", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    TrackedWorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseSets_TrackedWorkouts_TrackedWorkoutId",
                        column: x => x.TrackedWorkoutId,
                        principalTable: "TrackedWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 0, "2d0a0445-f848-4d02-b53f-83a1c8790863", "user9@example.com", true, "", "", false, null, "USER9@EXAMPLE.COM", "USER9@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAe3t+6ninoUkV6ttnnmqGCH31x4hVr4FWCBFfWMHUZs4V0OHXsHKfS+S0iVwBPsmw==", null, false, "ca636ad0-7c4a-4fb5-bd1f-32eb4f590fc6", false, "user9@example.com" },
                    { "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 0, "299ff753-a496-44ba-b285-b5ead2e2e669", "user3@example.com", true, "", "", false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDVrMPHgw6zu7/l43xtR3aKzwz3vhPiVB3n/C6R2TtdyLLf4IrGXOWwwsDl02bxLPw==", null, false, "625a4620-6873-4636-8664-4b2ab59677a8", false, "user3@example.com" },
                    { "501e6856-e59a-40f2-836c-ff613182c77b", 0, "39384cbe-2702-412a-9200-056240188fb0", "user2@example.com", true, "", "", false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPceVAH89mg/n/9ZouhzbXCqpEfjjZoIPUdtXsneD+Z/2t0w1OqGtoA+vUv+JV98Lg==", null, false, "3e9fba70-fef4-457b-850a-988f92690d8c", false, "user2@example.com" },
                    { "5ae3ad07-2478-448a-97ae-71c735e7d25a", 0, "ccd7f5a2-41a9-4b95-932a-33714d78bc2d", "user4@example.com", true, "", "", false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", "AQAAAAIAAYagAAAAEN8iI/sAo/4S0qY5UYTCedG3KuXgvJv+aHjlGjwwUs9wc+T2K0RJm4AnPsIt1Ys85w==", null, false, "f9f751ae-b0c0-452c-929a-701f02ec45d6", false, "user4@example.com" },
                    { "5da7d992-eb61-4d21-a650-056d11f2dfbb", 0, "0b47f835-de0f-4f91-ae76-eb34fb2273bc", "user1@example.com", true, "", "", false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOJnNollontmA26JY8KMJ1tx5h4xvhd7SZRSC+vuZkKM788A+wRsYIOipc/UZRgqtQ==", null, false, "42a629fd-1a42-446c-93b6-c457307cd1d0", false, "user1@example.com" },
                    { "72c62dc7-6ae6-416f-9239-c0161f39608c", 0, "67c0f8c2-b919-45c1-aff3-2993865afd20", "user8@example.com", true, "", "", false, null, "USER8@EXAMPLE.COM", "USER8@EXAMPLE.COM", "AQAAAAIAAYagAAAAECBKMkzAurTdF9qLaBeLdT3WJhvNphN8AflQVMC+Pzy4UDirIvzS56dQd8Jx0UXjgA==", null, false, "ee5aee24-ab56-4cdb-99ff-3e7aaca67c66", false, "user8@example.com" },
                    { "81b771c2-7a05-4661-8232-d0aa7e6fd490", 0, "f5f881d6-58bd-4c8f-b234-73d6bd14d472", "user10@example.com", true, "", "", false, null, "USER10@EXAMPLE.COM", "USER10@EXAMPLE.COM", "AQAAAAIAAYagAAAAEGVXuU1Ys3O5W4QPyMn97DASVCXx6TP6dN/HOzSJzPd2DJCU4CgOUQcocVT7CPGYfA==", null, false, "94bd3773-611c-41db-8b5a-3e72750c15ed", false, "user10@example.com" },
                    { "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 0, "e57ac41b-a7c7-429c-b9b6-24fc2a54c9d9", "user7@example.com", true, "", "", false, null, "USER7@EXAMPLE.COM", "USER7@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOoeBShpMlut4fikyiA9qTo4jec8oZgXeZu0jaMum75H8L1/iowAPmj4uoSEqeOheg==", null, false, "01605cef-e979-48f4-8c19-296026151336", false, "user7@example.com" },
                    { "ab6391ea-8589-4299-91af-c4491b2ec4f4", 0, "d90b72f6-8740-4961-99e8-0e70eac64bc7", "user6@example.com", true, "", "", false, null, "USER6@EXAMPLE.COM", "USER6@EXAMPLE.COM", "AQAAAAIAAYagAAAAEA+IoVrUBR51kxTIFTUiB3BcjaltEWFs9Ri+wca3I5GEOECl1CfmlyW6XVjpdHRUyg==", null, false, "71f2fa06-f675-41d7-b69c-cdeebbda32d3", false, "user6@example.com" },
                    { "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 0, "9eb717fe-0158-4e31-90d8-9d39ae96bc5a", "user5@example.com", true, "", "", false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", "AQAAAAIAAYagAAAAEF9LgKo0P38o0QK3YOjiAH3weAt8LXNMhhxacRMWobvZBJ3zU5rWuplm7GDC/0WVdw==", null, false, "8a87341a-d379-4a3e-b6c8-39c2b18e0286", false, "user5@example.com" },
                    { "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 0, "0a328bb4-89f5-4b74-b9ed-50921e19e004", "user0@example.com", true, "", "", false, null, "USER0@EXAMPLE.COM", "USER0@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPsGb/wk9sJslkmDGM6m+f8k83aEJWmLwLQ1I1K0P/U1Yf9iC54Rhs4grvaGWl39+w==", null, false, "b26453b1-4b74-49f8-9513-07fa35694844", false, "user0@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ApplicationUserId", "Carbohydrates", "Category", "Date", "Fats", "Protein", "TotalCalories" },
                values: new object[,]
                {
                    { 1, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 143.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1072), 34.0, 128.0, 1889.0 },
                    { 2, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 154.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1109), 35.0, 113.0, 1759.0 },
                    { 3, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 170.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1114), 39.0, 148.0, 1898.0 },
                    { 4, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 159.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1118), 46.0, 137.0, 1831.0 },
                    { 5, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 165.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1122), 42.0, 125.0, 1600.0 },
                    { 6, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 160.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1136), 47.0, 113.0, 1393.0 },
                    { 7, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 142.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1140), 37.0, 142.0, 1386.0 },
                    { 8, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 177.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1144), 33.0, 119.0, 1351.0 },
                    { 9, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 178.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1148), 45.0, 148.0, 1575.0 },
                    { 10, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 131.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1153), 39.0, 125.0, 1763.0 },
                    { 11, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 173.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1157), 44.0, 120.0, 1629.0 },
                    { 12, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 143.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1161), 44.0, 101.0, 1529.0 },
                    { 13, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 178.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1165), 31.0, 141.0, 1980.0 },
                    { 14, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", 145.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1170), 43.0, 146.0, 1615.0 },
                    { 15, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 148.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(62), 43.0, 102.0, 1543.0 },
                    { 16, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 175.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(94), 43.0, 146.0, 1566.0 },
                    { 17, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 169.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(98), 39.0, 127.0, 1387.0 },
                    { 18, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 140.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(114), 48.0, 102.0, 1982.0 },
                    { 19, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 177.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(118), 45.0, 110.0, 1406.0 },
                    { 20, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 158.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(122), 46.0, 100.0, 1738.0 },
                    { 21, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 162.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(126), 37.0, 149.0, 1872.0 },
                    { 22, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 175.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(129), 45.0, 130.0, 1468.0 },
                    { 23, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 164.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(133), 31.0, 141.0, 1731.0 },
                    { 24, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 178.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(137), 38.0, 128.0, 1406.0 },
                    { 25, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 141.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(141), 34.0, 127.0, 1312.0 },
                    { 26, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 150.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(144), 43.0, 135.0, 1934.0 },
                    { 27, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 171.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(148), 33.0, 112.0, 1676.0 },
                    { 28, "5da7d992-eb61-4d21-a650-056d11f2dfbb", 171.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(152), 49.0, 131.0, 1417.0 },
                    { 29, "501e6856-e59a-40f2-836c-ff613182c77b", 171.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9064), 40.0, 147.0, 1622.0 },
                    { 30, "501e6856-e59a-40f2-836c-ff613182c77b", 173.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9097), 36.0, 140.0, 1844.0 },
                    { 31, "501e6856-e59a-40f2-836c-ff613182c77b", 141.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9101), 42.0, 106.0, 1370.0 },
                    { 32, "501e6856-e59a-40f2-836c-ff613182c77b", 148.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9105), 41.0, 111.0, 1435.0 },
                    { 33, "501e6856-e59a-40f2-836c-ff613182c77b", 139.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9109), 42.0, 102.0, 1911.0 },
                    { 34, "501e6856-e59a-40f2-836c-ff613182c77b", 132.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9123), 45.0, 149.0, 1623.0 },
                    { 35, "501e6856-e59a-40f2-836c-ff613182c77b", 141.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9127), 43.0, 149.0, 1675.0 },
                    { 36, "501e6856-e59a-40f2-836c-ff613182c77b", 155.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9131), 30.0, 137.0, 1882.0 },
                    { 37, "501e6856-e59a-40f2-836c-ff613182c77b", 139.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9134), 36.0, 109.0, 1320.0 },
                    { 38, "501e6856-e59a-40f2-836c-ff613182c77b", 152.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9138), 30.0, 115.0, 1986.0 },
                    { 39, "501e6856-e59a-40f2-836c-ff613182c77b", 176.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9142), 41.0, 144.0, 1727.0 },
                    { 40, "501e6856-e59a-40f2-836c-ff613182c77b", 144.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9146), 37.0, 110.0, 1903.0 },
                    { 41, "501e6856-e59a-40f2-836c-ff613182c77b", 177.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9149), 42.0, 102.0, 1410.0 },
                    { 42, "501e6856-e59a-40f2-836c-ff613182c77b", 139.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9235), 49.0, 105.0, 1851.0 },
                    { 43, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 143.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5508), 38.0, 120.0, 1706.0 },
                    { 44, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 176.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5551), 38.0, 138.0, 1748.0 },
                    { 45, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 165.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5556), 43.0, 136.0, 1656.0 },
                    { 46, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 151.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5561), 47.0, 133.0, 1714.0 },
                    { 47, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 131.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5565), 43.0, 144.0, 1824.0 },
                    { 48, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 155.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5667), 35.0, 117.0, 1731.0 },
                    { 49, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 153.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5672), 38.0, 100.0, 1525.0 },
                    { 50, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 139.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5676), 49.0, 115.0, 1376.0 },
                    { 51, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 136.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5681), 35.0, 128.0, 1878.0 },
                    { 52, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 173.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5686), 44.0, 118.0, 1526.0 },
                    { 53, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 139.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5690), 43.0, 135.0, 1613.0 },
                    { 54, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 176.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5694), 44.0, 146.0, 1804.0 },
                    { 55, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 143.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5699), 32.0, 120.0, 1809.0 },
                    { 56, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", 139.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5703), 45.0, 103.0, 1786.0 },
                    { 57, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 155.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(605), 41.0, 130.0, 1784.0 },
                    { 58, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 170.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(636), 31.0, 111.0, 1883.0 },
                    { 59, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 143.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(640), 41.0, 116.0, 1734.0 },
                    { 60, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 143.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(644), 37.0, 105.0, 1446.0 },
                    { 61, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 166.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(647), 47.0, 113.0, 1921.0 },
                    { 62, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 160.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(651), 35.0, 138.0, 1647.0 },
                    { 63, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 131.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(654), 43.0, 105.0, 1304.0 },
                    { 64, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 149.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(658), 47.0, 140.0, 1935.0 },
                    { 65, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 171.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(661), 39.0, 130.0, 1388.0 },
                    { 66, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 173.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(679), 40.0, 142.0, 1369.0 },
                    { 67, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 160.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(683), 35.0, 144.0, 1645.0 },
                    { 68, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 157.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(686), 40.0, 135.0, 1998.0 },
                    { 69, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 161.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(690), 45.0, 138.0, 1375.0 },
                    { 70, "5ae3ad07-2478-448a-97ae-71c735e7d25a", 173.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(693), 47.0, 132.0, 1440.0 },
                    { 71, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 137.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4557), 37.0, 144.0, 1752.0 },
                    { 72, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 178.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4589), 34.0, 133.0, 1510.0 },
                    { 73, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 130.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4593), 40.0, 147.0, 1337.0 },
                    { 74, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 156.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4597), 45.0, 129.0, 1849.0 },
                    { 75, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 130.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4601), 36.0, 143.0, 1427.0 },
                    { 76, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 149.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4605), 32.0, 143.0, 1745.0 },
                    { 77, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 149.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4608), 41.0, 132.0, 1342.0 },
                    { 78, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 165.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4612), 35.0, 104.0, 1633.0 },
                    { 79, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 157.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4616), 41.0, 126.0, 1940.0 },
                    { 80, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 144.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4619), 37.0, 138.0, 1970.0 },
                    { 81, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 170.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4623), 38.0, 108.0, 1575.0 },
                    { 82, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 167.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4627), 38.0, 138.0, 1887.0 },
                    { 83, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 137.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4630), 38.0, 127.0, 1723.0 },
                    { 84, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", 139.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4634), 48.0, 104.0, 1850.0 },
                    { 85, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 152.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1181), 33.0, 135.0, 1764.0 },
                    { 86, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 135.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1215), 30.0, 128.0, 1821.0 },
                    { 87, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 134.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1219), 48.0, 100.0, 1530.0 },
                    { 88, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 131.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1223), 43.0, 110.0, 1671.0 },
                    { 89, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 155.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1227), 45.0, 115.0, 1574.0 },
                    { 90, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 134.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1231), 41.0, 144.0, 1691.0 },
                    { 91, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 167.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1234), 37.0, 142.0, 1316.0 },
                    { 92, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 167.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1238), 43.0, 126.0, 1374.0 },
                    { 93, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 167.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1242), 47.0, 114.0, 1818.0 },
                    { 94, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 131.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1246), 45.0, 102.0, 1951.0 },
                    { 95, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 159.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1250), 41.0, 139.0, 1646.0 },
                    { 96, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 142.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1254), 45.0, 144.0, 1790.0 },
                    { 97, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 132.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1257), 43.0, 149.0, 1449.0 },
                    { 98, "ab6391ea-8589-4299-91af-c4491b2ec4f4", 136.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1261), 34.0, 113.0, 1596.0 },
                    { 99, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 153.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8308), 48.0, 141.0, 1355.0 },
                    { 100, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 172.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8367), 35.0, 148.0, 1628.0 },
                    { 101, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 137.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8372), 42.0, 118.0, 1735.0 },
                    { 102, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 145.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8376), 32.0, 131.0, 1747.0 },
                    { 103, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 138.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8380), 37.0, 123.0, 1330.0 },
                    { 104, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 162.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8385), 48.0, 134.0, 1501.0 },
                    { 105, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 165.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8412), 32.0, 142.0, 1798.0 },
                    { 106, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 151.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8418), 30.0, 119.0, 1331.0 },
                    { 107, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 142.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8424), 35.0, 112.0, 1731.0 },
                    { 108, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 167.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8430), 47.0, 146.0, 1890.0 },
                    { 109, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 157.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8437), 33.0, 101.0, 1756.0 },
                    { 110, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 179.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8444), 45.0, 129.0, 1346.0 },
                    { 111, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 167.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8451), 35.0, 110.0, 1374.0 },
                    { 112, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", 178.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8458), 30.0, 141.0, 1302.0 },
                    { 113, "72c62dc7-6ae6-416f-9239-c0161f39608c", 132.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2176), 46.0, 133.0, 1450.0 },
                    { 114, "72c62dc7-6ae6-416f-9239-c0161f39608c", 172.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2242), 45.0, 118.0, 1992.0 },
                    { 115, "72c62dc7-6ae6-416f-9239-c0161f39608c", 146.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2251), 38.0, 100.0, 1412.0 },
                    { 116, "72c62dc7-6ae6-416f-9239-c0161f39608c", 132.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2259), 42.0, 137.0, 1478.0 },
                    { 117, "72c62dc7-6ae6-416f-9239-c0161f39608c", 171.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2267), 36.0, 132.0, 1449.0 },
                    { 118, "72c62dc7-6ae6-416f-9239-c0161f39608c", 172.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2275), 39.0, 104.0, 1747.0 },
                    { 119, "72c62dc7-6ae6-416f-9239-c0161f39608c", 163.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2283), 37.0, 105.0, 1433.0 },
                    { 120, "72c62dc7-6ae6-416f-9239-c0161f39608c", 161.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2290), 31.0, 141.0, 1997.0 },
                    { 121, "72c62dc7-6ae6-416f-9239-c0161f39608c", 168.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2446), 39.0, 139.0, 1648.0 },
                    { 122, "72c62dc7-6ae6-416f-9239-c0161f39608c", 175.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2456), 33.0, 142.0, 1899.0 },
                    { 123, "72c62dc7-6ae6-416f-9239-c0161f39608c", 174.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2463), 30.0, 124.0, 1448.0 },
                    { 124, "72c62dc7-6ae6-416f-9239-c0161f39608c", 160.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2471), 44.0, 112.0, 1988.0 },
                    { 125, "72c62dc7-6ae6-416f-9239-c0161f39608c", 140.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2480), 49.0, 111.0, 1491.0 },
                    { 126, "72c62dc7-6ae6-416f-9239-c0161f39608c", 151.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2488), 39.0, 113.0, 1610.0 },
                    { 127, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 159.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8235), 48.0, 144.0, 1724.0 },
                    { 128, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 174.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8265), 49.0, 115.0, 1822.0 },
                    { 129, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 163.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8269), 32.0, 108.0, 1775.0 },
                    { 130, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 159.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8540), 46.0, 117.0, 1580.0 },
                    { 131, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 137.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8546), 37.0, 104.0, 1340.0 },
                    { 132, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 162.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8551), 34.0, 128.0, 1829.0 },
                    { 133, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 162.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8554), 48.0, 122.0, 1600.0 },
                    { 134, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 132.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8558), 45.0, 115.0, 1451.0 },
                    { 135, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 138.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8562), 46.0, 124.0, 1702.0 },
                    { 136, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 178.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8566), 30.0, 143.0, 1642.0 },
                    { 137, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 166.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8570), 47.0, 141.0, 1532.0 },
                    { 138, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 134.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8573), 46.0, 145.0, 1816.0 },
                    { 139, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 160.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8577), 45.0, 114.0, 1329.0 },
                    { 140, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", 137.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8581), 45.0, 125.0, 1864.0 },
                    { 141, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 165.0, "Breakfast", new DateTime(2023, 3, 21, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8736), 47.0, 145.0, 1973.0 },
                    { 142, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 154.0, "Breakfast", new DateTime(2023, 3, 20, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8766), 45.0, 134.0, 1632.0 },
                    { 143, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 148.0, "Breakfast", new DateTime(2023, 3, 19, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8770), 43.0, 134.0, 1352.0 },
                    { 144, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 162.0, "Breakfast", new DateTime(2023, 3, 18, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8774), 43.0, 123.0, 1723.0 },
                    { 145, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 142.0, "Breakfast", new DateTime(2023, 3, 17, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8873), 39.0, 136.0, 1997.0 },
                    { 146, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 132.0, "Breakfast", new DateTime(2023, 3, 16, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8877), 44.0, 124.0, 1586.0 },
                    { 147, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 164.0, "Breakfast", new DateTime(2023, 3, 15, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8881), 45.0, 112.0, 1814.0 },
                    { 148, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 163.0, "Breakfast", new DateTime(2023, 3, 14, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8885), 40.0, 109.0, 1965.0 },
                    { 149, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 149.0, "Breakfast", new DateTime(2023, 3, 13, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8889), 48.0, 113.0, 1561.0 },
                    { 150, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 163.0, "Breakfast", new DateTime(2023, 3, 12, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8893), 48.0, 115.0, 1319.0 },
                    { 151, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 136.0, "Breakfast", new DateTime(2023, 3, 11, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8897), 43.0, 126.0, 1513.0 },
                    { 152, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 150.0, "Breakfast", new DateTime(2023, 3, 10, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8901), 37.0, 112.0, 1805.0 },
                    { 153, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 141.0, "Breakfast", new DateTime(2023, 3, 9, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8904), 33.0, 111.0, 1485.0 },
                    { 154, "81b771c2-7a05-4661-8232-d0aa7e6fd490", 171.0, "Breakfast", new DateTime(2023, 3, 8, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8908), 45.0, 139.0, 1714.0 }
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "ApplicationUserId", "Date", "Type", "Unit", "Value" },
                values: new object[,]
                {
                    { 1, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 21, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1094), "Weight", "kg", 81.0 },
                    { 2, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 20, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1111), "Weight", "kg", 80.0 },
                    { 3, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 19, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1116), "Weight", "kg", 82.0 },
                    { 4, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 18, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1120), "Weight", "kg", 84.0 },
                    { 5, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 17, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1124), "Weight", "kg", 84.0 },
                    { 6, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 16, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1138), "Weight", "kg", 80.0 },
                    { 7, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 15, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1142), "Weight", "kg", 81.0 },
                    { 8, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 14, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1145), "Weight", "kg", 85.0 },
                    { 9, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 13, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1149), "Weight", "kg", 80.0 },
                    { 10, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 12, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1155), "Weight", "kg", 83.0 },
                    { 11, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 11, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1159), "Weight", "kg", 86.0 },
                    { 12, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 10, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1163), "Weight", "kg", 82.0 },
                    { 13, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 9, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1168), "Weight", "kg", 83.0 },
                    { 14, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 8, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1172), "Weight", "kg", 83.0 },
                    { 15, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 21, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(87), "Weight", "kg", 82.0 },
                    { 16, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 20, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(95), "Weight", "kg", 86.0 },
                    { 17, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 19, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(99), "Weight", "kg", 86.0 },
                    { 18, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 18, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(116), "Weight", "kg", 83.0 },
                    { 19, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 17, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(120), "Weight", "kg", 83.0 },
                    { 20, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 16, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(124), "Weight", "kg", 81.0 },
                    { 21, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 15, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(127), "Weight", "kg", 82.0 },
                    { 22, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 14, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(131), "Weight", "kg", 85.0 },
                    { 23, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 13, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(135), "Weight", "kg", 84.0 },
                    { 24, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 12, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(138), "Weight", "kg", 81.0 },
                    { 25, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 11, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(142), "Weight", "kg", 85.0 },
                    { 26, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 10, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(146), "Weight", "kg", 81.0 },
                    { 27, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 9, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(150), "Weight", "kg", 80.0 },
                    { 28, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 8, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(154), "Weight", "kg", 86.0 },
                    { 29, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 21, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9088), "Weight", "kg", 86.0 },
                    { 30, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 20, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9098), "Weight", "kg", 83.0 },
                    { 31, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 19, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9103), "Weight", "kg", 85.0 },
                    { 32, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 18, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9106), "Weight", "kg", 86.0 },
                    { 33, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 17, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9110), "Weight", "kg", 83.0 },
                    { 34, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 16, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9125), "Weight", "kg", 84.0 },
                    { 35, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 15, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9129), "Weight", "kg", 80.0 },
                    { 36, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 14, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9132), "Weight", "kg", 80.0 },
                    { 37, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 13, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9136), "Weight", "kg", 86.0 },
                    { 38, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 12, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9140), "Weight", "kg", 86.0 },
                    { 39, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 11, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9143), "Weight", "kg", 81.0 },
                    { 40, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 10, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9147), "Weight", "kg", 83.0 },
                    { 41, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 9, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9232), "Weight", "kg", 82.0 },
                    { 42, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 8, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9237), "Weight", "kg", 80.0 },
                    { 43, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 21, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5538), "Weight", "kg", 83.0 },
                    { 44, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 20, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5553), "Weight", "kg", 83.0 },
                    { 45, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 19, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5558), "Weight", "kg", 84.0 },
                    { 46, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 18, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5563), "Weight", "kg", 84.0 },
                    { 47, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 17, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5664), "Weight", "kg", 83.0 },
                    { 48, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 16, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5669), "Weight", "kg", 81.0 },
                    { 49, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 15, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5674), "Weight", "kg", 86.0 },
                    { 50, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 14, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5678), "Weight", "kg", 86.0 },
                    { 51, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 13, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5683), "Weight", "kg", 83.0 },
                    { 52, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 12, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5688), "Weight", "kg", 80.0 },
                    { 53, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 11, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5692), "Weight", "kg", 85.0 },
                    { 54, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 10, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5696), "Weight", "kg", 82.0 },
                    { 55, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 9, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5700), "Weight", "kg", 80.0 },
                    { 56, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 8, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5705), "Weight", "kg", 84.0 },
                    { 57, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 21, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(627), "Weight", "kg", 85.0 },
                    { 58, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 20, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(638), "Weight", "kg", 82.0 },
                    { 59, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 19, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(641), "Weight", "kg", 83.0 },
                    { 60, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 18, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(645), "Weight", "kg", 84.0 },
                    { 61, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 17, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(648), "Weight", "kg", 81.0 },
                    { 62, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 16, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(652), "Weight", "kg", 82.0 },
                    { 63, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 15, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(655), "Weight", "kg", 81.0 },
                    { 64, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 14, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(659), "Weight", "kg", 84.0 },
                    { 65, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 13, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(662), "Weight", "kg", 84.0 },
                    { 66, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 12, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(680), "Weight", "kg", 86.0 },
                    { 67, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 11, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(684), "Weight", "kg", 85.0 },
                    { 68, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 10, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(688), "Weight", "kg", 84.0 },
                    { 69, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 9, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(691), "Weight", "kg", 80.0 },
                    { 70, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 8, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(694), "Weight", "kg", 86.0 },
                    { 71, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 21, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4580), "Weight", "kg", 84.0 },
                    { 72, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 20, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4590), "Weight", "kg", 85.0 },
                    { 73, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 19, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4594), "Weight", "kg", 85.0 },
                    { 74, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 18, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4599), "Weight", "kg", 86.0 },
                    { 75, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 17, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4602), "Weight", "kg", 80.0 },
                    { 76, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 16, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4606), "Weight", "kg", 82.0 },
                    { 77, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 15, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4610), "Weight", "kg", 84.0 },
                    { 78, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 14, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4613), "Weight", "kg", 86.0 },
                    { 79, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 13, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4617), "Weight", "kg", 84.0 },
                    { 80, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 12, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4621), "Weight", "kg", 83.0 },
                    { 81, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 11, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4624), "Weight", "kg", 80.0 },
                    { 82, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 10, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4628), "Weight", "kg", 81.0 },
                    { 83, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 9, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4632), "Weight", "kg", 82.0 },
                    { 84, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 8, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4636), "Weight", "kg", 85.0 },
                    { 85, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 21, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1204), "Weight", "kg", 85.0 },
                    { 86, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 20, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1217), "Weight", "kg", 82.0 },
                    { 87, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 19, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1221), "Weight", "kg", 83.0 },
                    { 88, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 18, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1225), "Weight", "kg", 80.0 },
                    { 89, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 17, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1228), "Weight", "kg", 81.0 },
                    { 90, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 16, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1232), "Weight", "kg", 82.0 },
                    { 91, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 15, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1236), "Weight", "kg", 80.0 },
                    { 92, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 14, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1240), "Weight", "kg", 84.0 },
                    { 93, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 13, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1244), "Weight", "kg", 80.0 },
                    { 94, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 12, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1248), "Weight", "kg", 80.0 },
                    { 95, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 11, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1252), "Weight", "kg", 85.0 },
                    { 96, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 10, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1255), "Weight", "kg", 86.0 },
                    { 97, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 9, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1259), "Weight", "kg", 86.0 },
                    { 98, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 8, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1262), "Weight", "kg", 84.0 },
                    { 99, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 21, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8348), "Weight", "kg", 85.0 },
                    { 100, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 20, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8369), "Weight", "kg", 85.0 },
                    { 101, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 19, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8374), "Weight", "kg", 84.0 },
                    { 102, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 18, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8378), "Weight", "kg", 84.0 },
                    { 103, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 17, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8382), "Weight", "kg", 85.0 },
                    { 104, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 16, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8387), "Weight", "kg", 81.0 },
                    { 105, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 15, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8415), "Weight", "kg", 80.0 },
                    { 106, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 14, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8420), "Weight", "kg", 85.0 },
                    { 107, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 13, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8427), "Weight", "kg", 83.0 },
                    { 108, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 12, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8433), "Weight", "kg", 83.0 },
                    { 109, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 11, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8441), "Weight", "kg", 81.0 },
                    { 110, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 10, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8447), "Weight", "kg", 84.0 },
                    { 111, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 9, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8453), "Weight", "kg", 82.0 },
                    { 112, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 8, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8461), "Weight", "kg", 83.0 },
                    { 113, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 21, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2225), "Weight", "kg", 80.0 },
                    { 114, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 20, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2246), "Weight", "kg", 82.0 },
                    { 115, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 19, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2254), "Weight", "kg", 80.0 },
                    { 116, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 18, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2263), "Weight", "kg", 86.0 },
                    { 117, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 17, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2271), "Weight", "kg", 85.0 },
                    { 118, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 16, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2279), "Weight", "kg", 82.0 },
                    { 119, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 15, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2287), "Weight", "kg", 84.0 },
                    { 120, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 14, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2293), "Weight", "kg", 80.0 },
                    { 121, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 13, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2451), "Weight", "kg", 83.0 },
                    { 122, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 12, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2459), "Weight", "kg", 83.0 },
                    { 123, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 11, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2467), "Weight", "kg", 85.0 },
                    { 124, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 10, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2475), "Weight", "kg", 84.0 },
                    { 125, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 9, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2483), "Weight", "kg", 82.0 },
                    { 126, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 8, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2491), "Weight", "kg", 81.0 },
                    { 127, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 21, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8256), "Weight", "kg", 86.0 },
                    { 128, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 20, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8267), "Weight", "kg", 85.0 },
                    { 129, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 19, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8271), "Weight", "kg", 85.0 },
                    { 130, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 18, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8544), "Weight", "kg", 84.0 },
                    { 131, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 17, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8548), "Weight", "kg", 81.0 },
                    { 132, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 16, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8552), "Weight", "kg", 82.0 },
                    { 133, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 15, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8556), "Weight", "kg", 81.0 },
                    { 134, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 14, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8559), "Weight", "kg", 80.0 },
                    { 135, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 13, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8563), "Weight", "kg", 86.0 },
                    { 136, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 12, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8568), "Weight", "kg", 80.0 },
                    { 137, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 11, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8571), "Weight", "kg", 85.0 },
                    { 138, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 10, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8575), "Weight", "kg", 81.0 },
                    { 139, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 9, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8579), "Weight", "kg", 81.0 },
                    { 140, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 8, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8583), "Weight", "kg", 83.0 },
                    { 141, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 21, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8758), "Weight", "kg", 82.0 },
                    { 142, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 20, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8768), "Weight", "kg", 86.0 },
                    { 143, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 19, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8772), "Weight", "kg", 80.0 },
                    { 144, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 18, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8776), "Weight", "kg", 81.0 },
                    { 145, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 17, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8875), "Weight", "kg", 86.0 },
                    { 146, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 16, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8879), "Weight", "kg", 85.0 },
                    { 147, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 15, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8883), "Weight", "kg", 82.0 },
                    { 148, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 14, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8886), "Weight", "kg", 81.0 },
                    { 149, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 13, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8891), "Weight", "kg", 86.0 },
                    { 150, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 12, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8895), "Weight", "kg", 80.0 },
                    { 151, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 11, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8898), "Weight", "kg", 82.0 },
                    { 152, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 10, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8902), "Weight", "kg", 84.0 },
                    { 153, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 9, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8906), "Weight", "kg", 82.0 },
                    { 154, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 8, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8909), "Weight", "kg", 84.0 }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "ApplicationUserId", "DateLastCompleted", "DayOfWeek", "Name" },
                values: new object[,]
                {
                    { 1, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 22, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1214), "Monday", "Workout1" },
                    { 2, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 22, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1281), "Wednesday", "Workout2" },
                    { 3, "e32a96e7-12a7-4f61-9f23-d4fc7116bc03", new DateTime(2023, 3, 22, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1441), "Friday", "Workout3" },
                    { 4, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 22, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(185), "Monday", "Workout1" },
                    { 5, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 22, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(378), "Wednesday", "Workout2" },
                    { 6, "5da7d992-eb61-4d21-a650-056d11f2dfbb", new DateTime(2023, 3, 22, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(402), "Friday", "Workout3" },
                    { 7, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 22, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9269), "Monday", "Workout1" },
                    { 8, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 22, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9329), "Wednesday", "Workout2" },
                    { 9, "501e6856-e59a-40f2-836c-ff613182c77b", new DateTime(2023, 3, 22, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9348), "Friday", "Workout3" },
                    { 10, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 22, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5745), "Monday", "Workout1" },
                    { 11, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 22, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5810), "Wednesday", "Workout2" },
                    { 12, "0c9c83c5-bca8-4326-ba5c-a6cfda5ff0f5", new DateTime(2023, 3, 22, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5843), "Friday", "Workout3" },
                    { 13, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 22, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(731), "Monday", "Workout1" },
                    { 14, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 22, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(786), "Wednesday", "Workout2" },
                    { 15, "5ae3ad07-2478-448a-97ae-71c735e7d25a", new DateTime(2023, 3, 22, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(803), "Friday", "Workout3" },
                    { 16, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 22, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4668), "Monday", "Workout1" },
                    { 17, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 22, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4847), "Wednesday", "Workout2" },
                    { 18, "dabf561a-7c09-4c0d-92e8-4bc33fbc5a7e", new DateTime(2023, 3, 22, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4876), "Friday", "Workout3" },
                    { 19, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 22, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1307), "Monday", "Workout1" },
                    { 20, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 22, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1518), "Wednesday", "Workout2" },
                    { 21, "ab6391ea-8589-4299-91af-c4491b2ec4f4", new DateTime(2023, 3, 22, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1662), "Friday", "Workout3" },
                    { 22, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 22, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8727), "Monday", "Workout1" },
                    { 23, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 22, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8907), "Wednesday", "Workout2" },
                    { 24, "a84a1d4a-10fe-46ba-a97d-5b51385c07e7", new DateTime(2023, 3, 22, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8995), "Friday", "Workout3" },
                    { 25, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 22, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2549), "Monday", "Workout1" },
                    { 26, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 22, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2647), "Wednesday", "Workout2" },
                    { 27, "72c62dc7-6ae6-416f-9239-c0161f39608c", new DateTime(2023, 3, 22, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2682), "Friday", "Workout3" },
                    { 28, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 22, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8629), "Monday", "Workout1" },
                    { 29, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 22, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8679), "Wednesday", "Workout2" },
                    { 30, "06c7fdb2-a38a-40ab-aa6e-ea2011b85b56", new DateTime(2023, 3, 22, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8739), "Friday", "Workout3" },
                    { 31, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 22, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8954), "Monday", "Workout1" },
                    { 32, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 22, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(9016), "Wednesday", "Workout2" },
                    { 33, "81b771c2-7a05-4661-8232-d0aa7e6fd490", new DateTime(2023, 3, 22, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(9033), "Friday", "Workout3" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "DefaultNumberOfSets", "Name", "TargetMuscle", "WorkoutId" },
                values: new object[,]
                {
                    { 1, 3, "Exercise1", "Muscle1", 1 },
                    { 2, 3, "Exercise2", "Muscle2", 1 },
                    { 3, 3, "Exercise3", "Muscle3", 1 },
                    { 4, 3, "Exercise1", "Muscle1", 2 },
                    { 5, 3, "Exercise2", "Muscle2", 2 },
                    { 6, 3, "Exercise3", "Muscle3", 2 },
                    { 7, 3, "Exercise1", "Muscle1", 3 },
                    { 8, 3, "Exercise2", "Muscle2", 3 },
                    { 9, 3, "Exercise3", "Muscle3", 3 },
                    { 10, 3, "Exercise1", "Muscle1", 4 },
                    { 11, 3, "Exercise2", "Muscle2", 4 },
                    { 12, 3, "Exercise3", "Muscle3", 4 },
                    { 13, 3, "Exercise1", "Muscle1", 5 },
                    { 14, 3, "Exercise2", "Muscle2", 5 },
                    { 15, 3, "Exercise3", "Muscle3", 5 },
                    { 16, 3, "Exercise1", "Muscle1", 6 },
                    { 17, 3, "Exercise2", "Muscle2", 6 },
                    { 18, 3, "Exercise3", "Muscle3", 6 },
                    { 19, 3, "Exercise1", "Muscle1", 7 },
                    { 20, 3, "Exercise2", "Muscle2", 7 },
                    { 21, 3, "Exercise3", "Muscle3", 7 },
                    { 22, 3, "Exercise1", "Muscle1", 8 },
                    { 23, 3, "Exercise2", "Muscle2", 8 },
                    { 24, 3, "Exercise3", "Muscle3", 8 },
                    { 25, 3, "Exercise1", "Muscle1", 9 },
                    { 26, 3, "Exercise2", "Muscle2", 9 },
                    { 27, 3, "Exercise3", "Muscle3", 9 },
                    { 28, 3, "Exercise1", "Muscle1", 10 },
                    { 29, 3, "Exercise2", "Muscle2", 10 },
                    { 30, 3, "Exercise3", "Muscle3", 10 },
                    { 31, 3, "Exercise1", "Muscle1", 11 },
                    { 32, 3, "Exercise2", "Muscle2", 11 },
                    { 33, 3, "Exercise3", "Muscle3", 11 },
                    { 34, 3, "Exercise1", "Muscle1", 12 },
                    { 35, 3, "Exercise2", "Muscle2", 12 },
                    { 36, 3, "Exercise3", "Muscle3", 12 },
                    { 37, 3, "Exercise1", "Muscle1", 13 },
                    { 38, 3, "Exercise2", "Muscle2", 13 },
                    { 39, 3, "Exercise3", "Muscle3", 13 },
                    { 40, 3, "Exercise1", "Muscle1", 14 },
                    { 41, 3, "Exercise2", "Muscle2", 14 },
                    { 42, 3, "Exercise3", "Muscle3", 14 },
                    { 43, 3, "Exercise1", "Muscle1", 15 },
                    { 44, 3, "Exercise2", "Muscle2", 15 },
                    { 45, 3, "Exercise3", "Muscle3", 15 },
                    { 46, 3, "Exercise1", "Muscle1", 16 },
                    { 47, 3, "Exercise2", "Muscle2", 16 },
                    { 48, 3, "Exercise3", "Muscle3", 16 },
                    { 49, 3, "Exercise1", "Muscle1", 17 },
                    { 50, 3, "Exercise2", "Muscle2", 17 },
                    { 51, 3, "Exercise3", "Muscle3", 17 },
                    { 52, 3, "Exercise1", "Muscle1", 18 },
                    { 53, 3, "Exercise2", "Muscle2", 18 },
                    { 54, 3, "Exercise3", "Muscle3", 18 },
                    { 55, 3, "Exercise1", "Muscle1", 19 },
                    { 56, 3, "Exercise2", "Muscle2", 19 },
                    { 57, 3, "Exercise3", "Muscle3", 19 },
                    { 58, 3, "Exercise1", "Muscle1", 20 },
                    { 59, 3, "Exercise2", "Muscle2", 20 },
                    { 60, 3, "Exercise3", "Muscle3", 20 },
                    { 61, 3, "Exercise1", "Muscle1", 21 },
                    { 62, 3, "Exercise2", "Muscle2", 21 },
                    { 63, 3, "Exercise3", "Muscle3", 21 },
                    { 64, 3, "Exercise1", "Muscle1", 22 },
                    { 65, 3, "Exercise2", "Muscle2", 22 },
                    { 66, 3, "Exercise3", "Muscle3", 22 },
                    { 67, 3, "Exercise1", "Muscle1", 23 },
                    { 68, 3, "Exercise2", "Muscle2", 23 },
                    { 69, 3, "Exercise3", "Muscle3", 23 },
                    { 70, 3, "Exercise1", "Muscle1", 24 },
                    { 71, 3, "Exercise2", "Muscle2", 24 },
                    { 72, 3, "Exercise3", "Muscle3", 24 },
                    { 73, 3, "Exercise1", "Muscle1", 25 },
                    { 74, 3, "Exercise2", "Muscle2", 25 },
                    { 75, 3, "Exercise3", "Muscle3", 25 },
                    { 76, 3, "Exercise1", "Muscle1", 26 },
                    { 77, 3, "Exercise2", "Muscle2", 26 },
                    { 78, 3, "Exercise3", "Muscle3", 26 },
                    { 79, 3, "Exercise1", "Muscle1", 27 },
                    { 80, 3, "Exercise2", "Muscle2", 27 },
                    { 81, 3, "Exercise3", "Muscle3", 27 },
                    { 82, 3, "Exercise1", "Muscle1", 28 },
                    { 83, 3, "Exercise2", "Muscle2", 28 },
                    { 84, 3, "Exercise3", "Muscle3", 28 },
                    { 85, 3, "Exercise1", "Muscle1", 29 },
                    { 86, 3, "Exercise2", "Muscle2", 29 },
                    { 87, 3, "Exercise3", "Muscle3", 29 },
                    { 88, 3, "Exercise1", "Muscle1", 30 },
                    { 89, 3, "Exercise2", "Muscle2", 30 },
                    { 90, 3, "Exercise3", "Muscle3", 30 },
                    { 91, 3, "Exercise1", "Muscle1", 31 },
                    { 92, 3, "Exercise2", "Muscle2", 31 },
                    { 93, 3, "Exercise3", "Muscle3", 31 },
                    { 94, 3, "Exercise1", "Muscle1", 32 },
                    { 95, 3, "Exercise2", "Muscle2", 32 },
                    { 96, 3, "Exercise3", "Muscle3", 32 },
                    { 97, 3, "Exercise1", "Muscle1", 33 },
                    { 98, 3, "Exercise2", "Muscle2", 33 },
                    { 99, 3, "Exercise3", "Muscle3", 33 }
                });

            migrationBuilder.InsertData(
                table: "TrackedWorkouts",
                columns: new[] { "Id", "EndTime", "IsCompleted", "Notes", "StartTime", "TotalVolume", "WorkoutId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 22, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1232), true, "Notes for TrackedWorkout1", new DateTime(2023, 3, 22, 14, 53, 15, 694, DateTimeKind.Local).AddTicks(1239), 1000.0, 1 },
                    { 2, new DateTime(2023, 3, 22, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1289), true, "Notes for TrackedWorkout2", new DateTime(2023, 3, 22, 14, 53, 15, 694, DateTimeKind.Local).AddTicks(1291), 1000.0, 2 },
                    { 3, new DateTime(2023, 3, 22, 16, 53, 15, 694, DateTimeKind.Local).AddTicks(1451), true, "Notes for TrackedWorkout3", new DateTime(2023, 3, 22, 14, 53, 15, 694, DateTimeKind.Local).AddTicks(1458), 1000.0, 3 },
                    { 4, new DateTime(2023, 3, 22, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(205), true, "Notes for TrackedWorkout4", new DateTime(2023, 3, 22, 14, 53, 15, 786, DateTimeKind.Local).AddTicks(209), 1000.0, 4 },
                    { 5, new DateTime(2023, 3, 22, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(387), true, "Notes for TrackedWorkout5", new DateTime(2023, 3, 22, 14, 53, 15, 786, DateTimeKind.Local).AddTicks(388), 1000.0, 5 },
                    { 6, new DateTime(2023, 3, 22, 16, 53, 15, 786, DateTimeKind.Local).AddTicks(409), true, "Notes for TrackedWorkout6", new DateTime(2023, 3, 22, 14, 53, 15, 786, DateTimeKind.Local).AddTicks(410), 1000.0, 6 },
                    { 7, new DateTime(2023, 3, 22, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9287), true, "Notes for TrackedWorkout7", new DateTime(2023, 3, 22, 14, 53, 15, 865, DateTimeKind.Local).AddTicks(9291), 1000.0, 7 },
                    { 8, new DateTime(2023, 3, 22, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9336), true, "Notes for TrackedWorkout8", new DateTime(2023, 3, 22, 14, 53, 15, 865, DateTimeKind.Local).AddTicks(9337), 1000.0, 8 },
                    { 9, new DateTime(2023, 3, 22, 16, 53, 15, 865, DateTimeKind.Local).AddTicks(9355), true, "Notes for TrackedWorkout9", new DateTime(2023, 3, 22, 14, 53, 15, 865, DateTimeKind.Local).AddTicks(9356), 1000.0, 9 },
                    { 10, new DateTime(2023, 3, 22, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5770), true, "Notes for TrackedWorkout10", new DateTime(2023, 3, 22, 14, 53, 15, 980, DateTimeKind.Local).AddTicks(5775), 1000.0, 10 },
                    { 11, new DateTime(2023, 3, 22, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5830), true, "Notes for TrackedWorkout11", new DateTime(2023, 3, 22, 14, 53, 15, 980, DateTimeKind.Local).AddTicks(5831), 1000.0, 11 },
                    { 12, new DateTime(2023, 3, 22, 16, 53, 15, 980, DateTimeKind.Local).AddTicks(5851), true, "Notes for TrackedWorkout12", new DateTime(2023, 3, 22, 14, 53, 15, 980, DateTimeKind.Local).AddTicks(5852), 1000.0, 12 },
                    { 13, new DateTime(2023, 3, 22, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(751), true, "Notes for TrackedWorkout13", new DateTime(2023, 3, 22, 14, 53, 16, 75, DateTimeKind.Local).AddTicks(755), 1000.0, 13 },
                    { 14, new DateTime(2023, 3, 22, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(793), true, "Notes for TrackedWorkout14", new DateTime(2023, 3, 22, 14, 53, 16, 75, DateTimeKind.Local).AddTicks(794), 1000.0, 14 },
                    { 15, new DateTime(2023, 3, 22, 16, 53, 16, 75, DateTimeKind.Local).AddTicks(850), true, "Notes for TrackedWorkout15", new DateTime(2023, 3, 22, 14, 53, 16, 75, DateTimeKind.Local).AddTicks(852), 1000.0, 15 },
                    { 16, new DateTime(2023, 3, 22, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4690), true, "Notes for TrackedWorkout16", new DateTime(2023, 3, 22, 14, 53, 16, 154, DateTimeKind.Local).AddTicks(4694), 1000.0, 16 },
                    { 17, new DateTime(2023, 3, 22, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4855), true, "Notes for TrackedWorkout17", new DateTime(2023, 3, 22, 14, 53, 16, 154, DateTimeKind.Local).AddTicks(4856), 1000.0, 17 },
                    { 18, new DateTime(2023, 3, 22, 16, 53, 16, 154, DateTimeKind.Local).AddTicks(4883), true, "Notes for TrackedWorkout18", new DateTime(2023, 3, 22, 14, 53, 16, 154, DateTimeKind.Local).AddTicks(4884), 1000.0, 18 },
                    { 19, new DateTime(2023, 3, 22, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1480), true, "Notes for TrackedWorkout19", new DateTime(2023, 3, 22, 14, 53, 16, 236, DateTimeKind.Local).AddTicks(1485), 1000.0, 19 },
                    { 20, new DateTime(2023, 3, 22, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1649), true, "Notes for TrackedWorkout20", new DateTime(2023, 3, 22, 14, 53, 16, 236, DateTimeKind.Local).AddTicks(1651), 1000.0, 20 },
                    { 21, new DateTime(2023, 3, 22, 16, 53, 16, 236, DateTimeKind.Local).AddTicks(1669), true, "Notes for TrackedWorkout21", new DateTime(2023, 3, 22, 14, 53, 16, 236, DateTimeKind.Local).AddTicks(1670), 1000.0, 21 },
                    { 22, new DateTime(2023, 3, 22, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8814), true, "Notes for TrackedWorkout22", new DateTime(2023, 3, 22, 14, 53, 16, 328, DateTimeKind.Local).AddTicks(8829), 1000.0, 22 },
                    { 23, new DateTime(2023, 3, 22, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(8941), true, "Notes for TrackedWorkout23", new DateTime(2023, 3, 22, 14, 53, 16, 328, DateTimeKind.Local).AddTicks(8947), 1000.0, 23 },
                    { 24, new DateTime(2023, 3, 22, 16, 53, 16, 328, DateTimeKind.Local).AddTicks(9027), true, "Notes for TrackedWorkout24", new DateTime(2023, 3, 22, 14, 53, 16, 328, DateTimeKind.Local).AddTicks(9032), 1000.0, 24 },
                    { 25, new DateTime(2023, 3, 22, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2586), true, "Notes for TrackedWorkout25", new DateTime(2023, 3, 22, 14, 53, 16, 462, DateTimeKind.Local).AddTicks(2592), 1000.0, 25 },
                    { 26, new DateTime(2023, 3, 22, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2661), true, "Notes for TrackedWorkout26", new DateTime(2023, 3, 22, 14, 53, 16, 462, DateTimeKind.Local).AddTicks(2664), 1000.0, 26 },
                    { 27, new DateTime(2023, 3, 22, 16, 53, 16, 462, DateTimeKind.Local).AddTicks(2696), true, "Notes for TrackedWorkout27", new DateTime(2023, 3, 22, 14, 53, 16, 462, DateTimeKind.Local).AddTicks(2698), 1000.0, 27 },
                    { 28, new DateTime(2023, 3, 22, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8648), true, "Notes for TrackedWorkout28", new DateTime(2023, 3, 22, 14, 53, 16, 547, DateTimeKind.Local).AddTicks(8650), 1000.0, 28 },
                    { 29, new DateTime(2023, 3, 22, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8686), true, "Notes for TrackedWorkout29", new DateTime(2023, 3, 22, 14, 53, 16, 547, DateTimeKind.Local).AddTicks(8687), 1000.0, 29 },
                    { 30, new DateTime(2023, 3, 22, 16, 53, 16, 547, DateTimeKind.Local).AddTicks(8745), true, "Notes for TrackedWorkout30", new DateTime(2023, 3, 22, 14, 53, 16, 547, DateTimeKind.Local).AddTicks(8747), 1000.0, 30 },
                    { 31, new DateTime(2023, 3, 22, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(8979), true, "Notes for TrackedWorkout31", new DateTime(2023, 3, 22, 14, 53, 16, 627, DateTimeKind.Local).AddTicks(8981), 1000.0, 31 },
                    { 32, new DateTime(2023, 3, 22, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(9022), true, "Notes for TrackedWorkout32", new DateTime(2023, 3, 22, 14, 53, 16, 627, DateTimeKind.Local).AddTicks(9024), 1000.0, 32 },
                    { 33, new DateTime(2023, 3, 22, 16, 53, 16, 627, DateTimeKind.Local).AddTicks(9040), true, "Notes for TrackedWorkout33", new DateTime(2023, 3, 22, 14, 53, 16, 627, DateTimeKind.Local).AddTicks(9041), 1000.0, 33 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseSets",
                columns: new[] { "Id", "ExerciseId", "ExerciseName", "IsComplete", "IsWarmup", "Reps", "TrackedWorkoutId", "Weight" },
                values: new object[,]
                {
                    { 4, 1, "Exercise1", true, false, 10, 1, 10.0 },
                    { 5, 1, "Exercise1", true, false, 10, 1, 10.0 },
                    { 6, 1, "Exercise1", true, false, 10, 1, 10.0 },
                    { 7, 2, "Exercise2", true, false, 10, 1, 10.0 },
                    { 8, 2, "Exercise2", true, false, 10, 1, 10.0 },
                    { 9, 2, "Exercise2", true, false, 10, 1, 10.0 },
                    { 10, 3, "Exercise3", true, false, 10, 1, 10.0 },
                    { 11, 3, "Exercise3", true, false, 10, 1, 10.0 },
                    { 12, 3, "Exercise3", true, false, 10, 1, 10.0 },
                    { 13, 4, "Exercise1", true, false, 10, 2, 10.0 },
                    { 14, 4, "Exercise1", true, false, 10, 2, 10.0 },
                    { 15, 4, "Exercise1", true, false, 10, 2, 10.0 },
                    { 16, 5, "Exercise2", true, false, 10, 2, 10.0 },
                    { 17, 5, "Exercise2", true, false, 10, 2, 10.0 },
                    { 18, 5, "Exercise2", true, false, 10, 2, 10.0 },
                    { 19, 6, "Exercise3", true, false, 10, 2, 10.0 },
                    { 20, 6, "Exercise3", true, false, 10, 2, 10.0 },
                    { 21, 6, "Exercise3", true, false, 10, 2, 10.0 },
                    { 22, 7, "Exercise1", true, false, 10, 3, 10.0 },
                    { 23, 7, "Exercise1", true, false, 10, 3, 10.0 },
                    { 24, 7, "Exercise1", true, false, 10, 3, 10.0 },
                    { 25, 8, "Exercise2", true, false, 10, 3, 10.0 },
                    { 26, 8, "Exercise2", true, false, 10, 3, 10.0 },
                    { 27, 8, "Exercise2", true, false, 10, 3, 10.0 },
                    { 28, 9, "Exercise3", true, false, 10, 3, 10.0 },
                    { 29, 9, "Exercise3", true, false, 10, 3, 10.0 },
                    { 30, 9, "Exercise3", true, false, 10, 3, 10.0 },
                    { 31, 10, "Exercise1", true, false, 10, 4, 10.0 },
                    { 32, 10, "Exercise1", true, false, 10, 4, 10.0 },
                    { 33, 10, "Exercise1", true, false, 10, 4, 10.0 },
                    { 34, 11, "Exercise2", true, false, 10, 4, 10.0 },
                    { 35, 11, "Exercise2", true, false, 10, 4, 10.0 },
                    { 36, 11, "Exercise2", true, false, 10, 4, 10.0 },
                    { 37, 12, "Exercise3", true, false, 10, 4, 10.0 },
                    { 38, 12, "Exercise3", true, false, 10, 4, 10.0 },
                    { 39, 12, "Exercise3", true, false, 10, 4, 10.0 },
                    { 40, 13, "Exercise1", true, false, 10, 5, 10.0 },
                    { 41, 13, "Exercise1", true, false, 10, 5, 10.0 },
                    { 42, 13, "Exercise1", true, false, 10, 5, 10.0 },
                    { 43, 14, "Exercise2", true, false, 10, 5, 10.0 },
                    { 44, 14, "Exercise2", true, false, 10, 5, 10.0 },
                    { 45, 14, "Exercise2", true, false, 10, 5, 10.0 },
                    { 46, 15, "Exercise3", true, false, 10, 5, 10.0 },
                    { 47, 15, "Exercise3", true, false, 10, 5, 10.0 },
                    { 48, 15, "Exercise3", true, false, 10, 5, 10.0 },
                    { 49, 16, "Exercise1", true, false, 10, 6, 10.0 },
                    { 50, 16, "Exercise1", true, false, 10, 6, 10.0 },
                    { 51, 16, "Exercise1", true, false, 10, 6, 10.0 },
                    { 52, 17, "Exercise2", true, false, 10, 6, 10.0 },
                    { 53, 17, "Exercise2", true, false, 10, 6, 10.0 },
                    { 54, 17, "Exercise2", true, false, 10, 6, 10.0 },
                    { 55, 18, "Exercise3", true, false, 10, 6, 10.0 },
                    { 56, 18, "Exercise3", true, false, 10, 6, 10.0 },
                    { 57, 18, "Exercise3", true, false, 10, 6, 10.0 },
                    { 58, 19, "Exercise1", true, false, 10, 7, 10.0 },
                    { 59, 19, "Exercise1", true, false, 10, 7, 10.0 },
                    { 60, 19, "Exercise1", true, false, 10, 7, 10.0 },
                    { 61, 20, "Exercise2", true, false, 10, 7, 10.0 },
                    { 62, 20, "Exercise2", true, false, 10, 7, 10.0 },
                    { 63, 20, "Exercise2", true, false, 10, 7, 10.0 },
                    { 64, 21, "Exercise3", true, false, 10, 7, 10.0 },
                    { 65, 21, "Exercise3", true, false, 10, 7, 10.0 },
                    { 66, 21, "Exercise3", true, false, 10, 7, 10.0 },
                    { 67, 22, "Exercise1", true, false, 10, 8, 10.0 },
                    { 68, 22, "Exercise1", true, false, 10, 8, 10.0 },
                    { 69, 22, "Exercise1", true, false, 10, 8, 10.0 },
                    { 70, 23, "Exercise2", true, false, 10, 8, 10.0 },
                    { 71, 23, "Exercise2", true, false, 10, 8, 10.0 },
                    { 72, 23, "Exercise2", true, false, 10, 8, 10.0 },
                    { 73, 24, "Exercise3", true, false, 10, 8, 10.0 },
                    { 74, 24, "Exercise3", true, false, 10, 8, 10.0 },
                    { 75, 24, "Exercise3", true, false, 10, 8, 10.0 },
                    { 76, 25, "Exercise1", true, false, 10, 9, 10.0 },
                    { 77, 25, "Exercise1", true, false, 10, 9, 10.0 },
                    { 78, 25, "Exercise1", true, false, 10, 9, 10.0 },
                    { 79, 26, "Exercise2", true, false, 10, 9, 10.0 },
                    { 80, 26, "Exercise2", true, false, 10, 9, 10.0 },
                    { 81, 26, "Exercise2", true, false, 10, 9, 10.0 },
                    { 82, 27, "Exercise3", true, false, 10, 9, 10.0 },
                    { 83, 27, "Exercise3", true, false, 10, 9, 10.0 },
                    { 84, 27, "Exercise3", true, false, 10, 9, 10.0 },
                    { 85, 28, "Exercise1", true, false, 10, 10, 10.0 },
                    { 86, 28, "Exercise1", true, false, 10, 10, 10.0 },
                    { 87, 28, "Exercise1", true, false, 10, 10, 10.0 },
                    { 88, 29, "Exercise2", true, false, 10, 10, 10.0 },
                    { 89, 29, "Exercise2", true, false, 10, 10, 10.0 },
                    { 90, 29, "Exercise2", true, false, 10, 10, 10.0 },
                    { 91, 30, "Exercise3", true, false, 10, 10, 10.0 },
                    { 92, 30, "Exercise3", true, false, 10, 10, 10.0 },
                    { 93, 30, "Exercise3", true, false, 10, 10, 10.0 },
                    { 94, 31, "Exercise1", true, false, 10, 11, 10.0 },
                    { 95, 31, "Exercise1", true, false, 10, 11, 10.0 },
                    { 96, 31, "Exercise1", true, false, 10, 11, 10.0 },
                    { 97, 32, "Exercise2", true, false, 10, 11, 10.0 },
                    { 98, 32, "Exercise2", true, false, 10, 11, 10.0 },
                    { 99, 32, "Exercise2", true, false, 10, 11, 10.0 },
                    { 100, 33, "Exercise3", true, false, 10, 11, 10.0 },
                    { 101, 33, "Exercise3", true, false, 10, 11, 10.0 },
                    { 102, 33, "Exercise3", true, false, 10, 11, 10.0 },
                    { 103, 34, "Exercise1", true, false, 10, 12, 10.0 },
                    { 104, 34, "Exercise1", true, false, 10, 12, 10.0 },
                    { 105, 34, "Exercise1", true, false, 10, 12, 10.0 },
                    { 106, 35, "Exercise2", true, false, 10, 12, 10.0 },
                    { 107, 35, "Exercise2", true, false, 10, 12, 10.0 },
                    { 108, 35, "Exercise2", true, false, 10, 12, 10.0 },
                    { 109, 36, "Exercise3", true, false, 10, 12, 10.0 },
                    { 110, 36, "Exercise3", true, false, 10, 12, 10.0 },
                    { 111, 36, "Exercise3", true, false, 10, 12, 10.0 },
                    { 112, 37, "Exercise1", true, false, 10, 13, 10.0 },
                    { 113, 37, "Exercise1", true, false, 10, 13, 10.0 },
                    { 114, 37, "Exercise1", true, false, 10, 13, 10.0 },
                    { 115, 38, "Exercise2", true, false, 10, 13, 10.0 },
                    { 116, 38, "Exercise2", true, false, 10, 13, 10.0 },
                    { 117, 38, "Exercise2", true, false, 10, 13, 10.0 },
                    { 118, 39, "Exercise3", true, false, 10, 13, 10.0 },
                    { 119, 39, "Exercise3", true, false, 10, 13, 10.0 },
                    { 120, 39, "Exercise3", true, false, 10, 13, 10.0 },
                    { 121, 40, "Exercise1", true, false, 10, 14, 10.0 },
                    { 122, 40, "Exercise1", true, false, 10, 14, 10.0 },
                    { 123, 40, "Exercise1", true, false, 10, 14, 10.0 },
                    { 124, 41, "Exercise2", true, false, 10, 14, 10.0 },
                    { 125, 41, "Exercise2", true, false, 10, 14, 10.0 },
                    { 126, 41, "Exercise2", true, false, 10, 14, 10.0 },
                    { 127, 42, "Exercise3", true, false, 10, 14, 10.0 },
                    { 128, 42, "Exercise3", true, false, 10, 14, 10.0 },
                    { 129, 42, "Exercise3", true, false, 10, 14, 10.0 },
                    { 130, 43, "Exercise1", true, false, 10, 15, 10.0 },
                    { 131, 43, "Exercise1", true, false, 10, 15, 10.0 },
                    { 132, 43, "Exercise1", true, false, 10, 15, 10.0 },
                    { 133, 44, "Exercise2", true, false, 10, 15, 10.0 },
                    { 134, 44, "Exercise2", true, false, 10, 15, 10.0 },
                    { 135, 44, "Exercise2", true, false, 10, 15, 10.0 },
                    { 136, 45, "Exercise3", true, false, 10, 15, 10.0 },
                    { 137, 45, "Exercise3", true, false, 10, 15, 10.0 },
                    { 138, 45, "Exercise3", true, false, 10, 15, 10.0 },
                    { 139, 46, "Exercise1", true, false, 10, 16, 10.0 },
                    { 140, 46, "Exercise1", true, false, 10, 16, 10.0 },
                    { 141, 46, "Exercise1", true, false, 10, 16, 10.0 },
                    { 142, 47, "Exercise2", true, false, 10, 16, 10.0 },
                    { 143, 47, "Exercise2", true, false, 10, 16, 10.0 },
                    { 144, 47, "Exercise2", true, false, 10, 16, 10.0 },
                    { 145, 48, "Exercise3", true, false, 10, 16, 10.0 },
                    { 146, 48, "Exercise3", true, false, 10, 16, 10.0 },
                    { 147, 48, "Exercise3", true, false, 10, 16, 10.0 },
                    { 148, 49, "Exercise1", true, false, 10, 17, 10.0 },
                    { 149, 49, "Exercise1", true, false, 10, 17, 10.0 },
                    { 150, 49, "Exercise1", true, false, 10, 17, 10.0 },
                    { 151, 50, "Exercise2", true, false, 10, 17, 10.0 },
                    { 152, 50, "Exercise2", true, false, 10, 17, 10.0 },
                    { 153, 50, "Exercise2", true, false, 10, 17, 10.0 },
                    { 154, 51, "Exercise3", true, false, 10, 17, 10.0 },
                    { 155, 51, "Exercise3", true, false, 10, 17, 10.0 },
                    { 156, 51, "Exercise3", true, false, 10, 17, 10.0 },
                    { 157, 52, "Exercise1", true, false, 10, 18, 10.0 },
                    { 158, 52, "Exercise1", true, false, 10, 18, 10.0 },
                    { 159, 52, "Exercise1", true, false, 10, 18, 10.0 },
                    { 160, 53, "Exercise2", true, false, 10, 18, 10.0 },
                    { 161, 53, "Exercise2", true, false, 10, 18, 10.0 },
                    { 162, 53, "Exercise2", true, false, 10, 18, 10.0 },
                    { 163, 54, "Exercise3", true, false, 10, 18, 10.0 },
                    { 164, 54, "Exercise3", true, false, 10, 18, 10.0 },
                    { 165, 54, "Exercise3", true, false, 10, 18, 10.0 },
                    { 166, 55, "Exercise1", true, false, 10, 19, 10.0 },
                    { 167, 55, "Exercise1", true, false, 10, 19, 10.0 },
                    { 168, 55, "Exercise1", true, false, 10, 19, 10.0 },
                    { 169, 56, "Exercise2", true, false, 10, 19, 10.0 },
                    { 170, 56, "Exercise2", true, false, 10, 19, 10.0 },
                    { 171, 56, "Exercise2", true, false, 10, 19, 10.0 },
                    { 172, 57, "Exercise3", true, false, 10, 19, 10.0 },
                    { 173, 57, "Exercise3", true, false, 10, 19, 10.0 },
                    { 174, 57, "Exercise3", true, false, 10, 19, 10.0 },
                    { 175, 58, "Exercise1", true, false, 10, 20, 10.0 },
                    { 176, 58, "Exercise1", true, false, 10, 20, 10.0 },
                    { 177, 58, "Exercise1", true, false, 10, 20, 10.0 },
                    { 178, 59, "Exercise2", true, false, 10, 20, 10.0 },
                    { 179, 59, "Exercise2", true, false, 10, 20, 10.0 },
                    { 180, 59, "Exercise2", true, false, 10, 20, 10.0 },
                    { 181, 60, "Exercise3", true, false, 10, 20, 10.0 },
                    { 182, 60, "Exercise3", true, false, 10, 20, 10.0 },
                    { 183, 60, "Exercise3", true, false, 10, 20, 10.0 },
                    { 184, 61, "Exercise1", true, false, 10, 21, 10.0 },
                    { 185, 61, "Exercise1", true, false, 10, 21, 10.0 },
                    { 186, 61, "Exercise1", true, false, 10, 21, 10.0 },
                    { 187, 62, "Exercise2", true, false, 10, 21, 10.0 },
                    { 188, 62, "Exercise2", true, false, 10, 21, 10.0 },
                    { 189, 62, "Exercise2", true, false, 10, 21, 10.0 },
                    { 190, 63, "Exercise3", true, false, 10, 21, 10.0 },
                    { 191, 63, "Exercise3", true, false, 10, 21, 10.0 },
                    { 192, 63, "Exercise3", true, false, 10, 21, 10.0 },
                    { 193, 64, "Exercise1", true, false, 10, 22, 10.0 },
                    { 194, 64, "Exercise1", true, false, 10, 22, 10.0 },
                    { 195, 64, "Exercise1", true, false, 10, 22, 10.0 },
                    { 196, 65, "Exercise2", true, false, 10, 22, 10.0 },
                    { 197, 65, "Exercise2", true, false, 10, 22, 10.0 },
                    { 198, 65, "Exercise2", true, false, 10, 22, 10.0 },
                    { 199, 66, "Exercise3", true, false, 10, 22, 10.0 },
                    { 200, 66, "Exercise3", true, false, 10, 22, 10.0 },
                    { 201, 66, "Exercise3", true, false, 10, 22, 10.0 },
                    { 202, 67, "Exercise1", true, false, 10, 23, 10.0 },
                    { 203, 67, "Exercise1", true, false, 10, 23, 10.0 },
                    { 204, 67, "Exercise1", true, false, 10, 23, 10.0 },
                    { 205, 68, "Exercise2", true, false, 10, 23, 10.0 },
                    { 206, 68, "Exercise2", true, false, 10, 23, 10.0 },
                    { 207, 68, "Exercise2", true, false, 10, 23, 10.0 },
                    { 208, 69, "Exercise3", true, false, 10, 23, 10.0 },
                    { 209, 69, "Exercise3", true, false, 10, 23, 10.0 },
                    { 210, 69, "Exercise3", true, false, 10, 23, 10.0 },
                    { 211, 70, "Exercise1", true, false, 10, 24, 10.0 },
                    { 212, 70, "Exercise1", true, false, 10, 24, 10.0 },
                    { 213, 70, "Exercise1", true, false, 10, 24, 10.0 },
                    { 214, 71, "Exercise2", true, false, 10, 24, 10.0 },
                    { 215, 71, "Exercise2", true, false, 10, 24, 10.0 },
                    { 216, 71, "Exercise2", true, false, 10, 24, 10.0 },
                    { 217, 72, "Exercise3", true, false, 10, 24, 10.0 },
                    { 218, 72, "Exercise3", true, false, 10, 24, 10.0 },
                    { 219, 72, "Exercise3", true, false, 10, 24, 10.0 },
                    { 220, 73, "Exercise1", true, false, 10, 25, 10.0 },
                    { 221, 73, "Exercise1", true, false, 10, 25, 10.0 },
                    { 222, 73, "Exercise1", true, false, 10, 25, 10.0 },
                    { 223, 74, "Exercise2", true, false, 10, 25, 10.0 },
                    { 224, 74, "Exercise2", true, false, 10, 25, 10.0 },
                    { 225, 74, "Exercise2", true, false, 10, 25, 10.0 },
                    { 226, 75, "Exercise3", true, false, 10, 25, 10.0 },
                    { 227, 75, "Exercise3", true, false, 10, 25, 10.0 },
                    { 228, 75, "Exercise3", true, false, 10, 25, 10.0 },
                    { 229, 76, "Exercise1", true, false, 10, 26, 10.0 },
                    { 230, 76, "Exercise1", true, false, 10, 26, 10.0 },
                    { 231, 76, "Exercise1", true, false, 10, 26, 10.0 },
                    { 232, 77, "Exercise2", true, false, 10, 26, 10.0 },
                    { 233, 77, "Exercise2", true, false, 10, 26, 10.0 },
                    { 234, 77, "Exercise2", true, false, 10, 26, 10.0 },
                    { 235, 78, "Exercise3", true, false, 10, 26, 10.0 },
                    { 236, 78, "Exercise3", true, false, 10, 26, 10.0 },
                    { 237, 78, "Exercise3", true, false, 10, 26, 10.0 },
                    { 238, 79, "Exercise1", true, false, 10, 27, 10.0 },
                    { 239, 79, "Exercise1", true, false, 10, 27, 10.0 },
                    { 240, 79, "Exercise1", true, false, 10, 27, 10.0 },
                    { 241, 80, "Exercise2", true, false, 10, 27, 10.0 },
                    { 242, 80, "Exercise2", true, false, 10, 27, 10.0 },
                    { 243, 80, "Exercise2", true, false, 10, 27, 10.0 },
                    { 244, 81, "Exercise3", true, false, 10, 27, 10.0 },
                    { 245, 81, "Exercise3", true, false, 10, 27, 10.0 },
                    { 246, 81, "Exercise3", true, false, 10, 27, 10.0 },
                    { 247, 82, "Exercise1", true, false, 10, 28, 10.0 },
                    { 248, 82, "Exercise1", true, false, 10, 28, 10.0 },
                    { 249, 82, "Exercise1", true, false, 10, 28, 10.0 },
                    { 250, 83, "Exercise2", true, false, 10, 28, 10.0 },
                    { 251, 83, "Exercise2", true, false, 10, 28, 10.0 },
                    { 252, 83, "Exercise2", true, false, 10, 28, 10.0 },
                    { 253, 84, "Exercise3", true, false, 10, 28, 10.0 },
                    { 254, 84, "Exercise3", true, false, 10, 28, 10.0 },
                    { 255, 84, "Exercise3", true, false, 10, 28, 10.0 },
                    { 256, 85, "Exercise1", true, false, 10, 29, 10.0 },
                    { 257, 85, "Exercise1", true, false, 10, 29, 10.0 },
                    { 258, 85, "Exercise1", true, false, 10, 29, 10.0 },
                    { 259, 86, "Exercise2", true, false, 10, 29, 10.0 },
                    { 260, 86, "Exercise2", true, false, 10, 29, 10.0 },
                    { 261, 86, "Exercise2", true, false, 10, 29, 10.0 },
                    { 262, 87, "Exercise3", true, false, 10, 29, 10.0 },
                    { 263, 87, "Exercise3", true, false, 10, 29, 10.0 },
                    { 264, 87, "Exercise3", true, false, 10, 29, 10.0 },
                    { 265, 88, "Exercise1", true, false, 10, 30, 10.0 },
                    { 266, 88, "Exercise1", true, false, 10, 30, 10.0 },
                    { 267, 88, "Exercise1", true, false, 10, 30, 10.0 },
                    { 268, 89, "Exercise2", true, false, 10, 30, 10.0 },
                    { 269, 89, "Exercise2", true, false, 10, 30, 10.0 },
                    { 270, 89, "Exercise2", true, false, 10, 30, 10.0 },
                    { 271, 90, "Exercise3", true, false, 10, 30, 10.0 },
                    { 272, 90, "Exercise3", true, false, 10, 30, 10.0 },
                    { 273, 90, "Exercise3", true, false, 10, 30, 10.0 },
                    { 274, 91, "Exercise1", true, false, 10, 31, 10.0 },
                    { 275, 91, "Exercise1", true, false, 10, 31, 10.0 },
                    { 276, 91, "Exercise1", true, false, 10, 31, 10.0 },
                    { 277, 92, "Exercise2", true, false, 10, 31, 10.0 },
                    { 278, 92, "Exercise2", true, false, 10, 31, 10.0 },
                    { 279, 92, "Exercise2", true, false, 10, 31, 10.0 },
                    { 280, 93, "Exercise3", true, false, 10, 31, 10.0 },
                    { 281, 93, "Exercise3", true, false, 10, 31, 10.0 },
                    { 282, 93, "Exercise3", true, false, 10, 31, 10.0 },
                    { 283, 94, "Exercise1", true, false, 10, 32, 10.0 },
                    { 284, 94, "Exercise1", true, false, 10, 32, 10.0 },
                    { 285, 94, "Exercise1", true, false, 10, 32, 10.0 },
                    { 286, 95, "Exercise2", true, false, 10, 32, 10.0 },
                    { 287, 95, "Exercise2", true, false, 10, 32, 10.0 },
                    { 288, 95, "Exercise2", true, false, 10, 32, 10.0 },
                    { 289, 96, "Exercise3", true, false, 10, 32, 10.0 },
                    { 290, 96, "Exercise3", true, false, 10, 32, 10.0 },
                    { 291, 96, "Exercise3", true, false, 10, 32, 10.0 },
                    { 292, 97, "Exercise1", true, false, 10, 33, 10.0 },
                    { 293, 97, "Exercise1", true, false, 10, 33, 10.0 },
                    { 294, 97, "Exercise1", true, false, 10, 33, 10.0 },
                    { 295, 98, "Exercise2", true, false, 10, 33, 10.0 },
                    { 296, 98, "Exercise2", true, false, 10, 33, 10.0 },
                    { 297, 98, "Exercise2", true, false, 10, 33, 10.0 },
                    { 298, 99, "Exercise3", true, false, 10, 33, 10.0 },
                    { 299, 99, "Exercise3", true, false, 10, 33, 10.0 },
                    { 300, 99, "Exercise3", true, false, 10, 33, 10.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_TrackedWorkoutId",
                table: "ExerciseSets",
                column: "TrackedWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_ApplicationUserId",
                table: "Meals",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_ApplicationUserId",
                table: "Measurements",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_TrackedWorkouts_WorkoutId",
                table: "TrackedWorkouts",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ApplicationUserId",
                table: "Workouts",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TrackedWorkouts");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
