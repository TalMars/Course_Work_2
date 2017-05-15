using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWork_2.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prototypes",
                columns: table => new
                {
                    PrototypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LastRecordingDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prototypes", x => x.PrototypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Biography = table.Column<string>(nullable: true),
                    LastRecordingDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PrototypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Prototypes_PrototypeId",
                        column: x => x.PrototypeId,
                        principalTable: "Prototypes",
                        principalColumn: "PrototypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EmotionVideoTimeScale = table.Column<double>(nullable: false),
                    OperationLocation = table.Column<string>(nullable: true),
                    PathToVideo = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmotionFragments",
                columns: table => new
                {
                    EmotionFragmentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Duration = table.Column<long>(nullable: false),
                    Interval = table.Column<long>(nullable: true),
                    RecordId = table.Column<int>(nullable: false),
                    Start = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionFragments", x => x.EmotionFragmentId);
                    table.ForeignKey(
                        name: "FK_EmotionFragments_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordScreens",
                columns: table => new
                {
                    RecordScreenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PathToHeatMapScreen = table.Column<string>(nullable: true),
                    PathToOriginalScreen = table.Column<string>(nullable: true),
                    PointsText = table.Column<string>(nullable: true),
                    RecordId = table.Column<int>(nullable: false),
                    UriPage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordScreens", x => x.RecordScreenId);
                    table.ForeignKey(
                        name: "FK_RecordScreens_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordSettings",
                columns: table => new
                {
                    RecordSettingsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrontCamera = table.Column<bool>(nullable: false),
                    RecordId = table.Column<int>(nullable: false),
                    Touches = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordSettings", x => x.RecordSettingsId);
                    table.ForeignKey(
                        name: "FK_RecordSettings_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmotionScores",
                columns: table => new
                {
                    EmotionMeanScoresId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AngerScore = table.Column<float>(nullable: false),
                    ContemptScore = table.Column<float>(nullable: false),
                    DisgustScore = table.Column<float>(nullable: false),
                    EmotionFragmentId = table.Column<int>(nullable: false),
                    FearScore = table.Column<float>(nullable: false),
                    HappinessScore = table.Column<float>(nullable: false),
                    NeutralScore = table.Column<float>(nullable: false),
                    SadnessScore = table.Column<float>(nullable: false),
                    SurpriseScore = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionScores", x => x.EmotionMeanScoresId);
                    table.ForeignKey(
                        name: "FK_EmotionScores_EmotionFragments_EmotionFragmentId",
                        column: x => x.EmotionFragmentId,
                        principalTable: "EmotionFragments",
                        principalColumn: "EmotionFragmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmotionFragments_RecordId",
                table: "EmotionFragments",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_EmotionScores_EmotionFragmentId",
                table: "EmotionScores",
                column: "EmotionFragmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                table: "Records",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordScreens_RecordId",
                table: "RecordScreens",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordSettings_RecordId",
                table: "RecordSettings",
                column: "RecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrototypeId",
                table: "Users",
                column: "PrototypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmotionScores");

            migrationBuilder.DropTable(
                name: "RecordScreens");

            migrationBuilder.DropTable(
                name: "RecordSettings");

            migrationBuilder.DropTable(
                name: "EmotionFragments");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Prototypes");
        }
    }
}
