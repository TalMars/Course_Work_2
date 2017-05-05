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
                name: "RecordsPrototype",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PathToVideo = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordsPrototype", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_RecordsPrototype_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordsScreens",
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
                    table.PrimaryKey("PK_RecordsScreens", x => x.RecordScreenId);
                    table.ForeignKey(
                        name: "FK_RecordsScreens_RecordsPrototype_RecordId",
                        column: x => x.RecordId,
                        principalTable: "RecordsPrototype",
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
                        name: "FK_RecordSettings_RecordsPrototype_RecordId",
                        column: x => x.RecordId,
                        principalTable: "RecordsPrototype",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordsPrototype_UserId",
                table: "RecordsPrototype",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordsScreens_RecordId",
                table: "RecordsScreens",
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
                name: "RecordsScreens");

            migrationBuilder.DropTable(
                name: "RecordSettings");

            migrationBuilder.DropTable(
                name: "RecordsPrototype");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Prototypes");
        }
    }
}
