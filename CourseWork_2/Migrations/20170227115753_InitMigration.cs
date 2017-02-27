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
                name: "PrototypesSettings",
                columns: table => new
                {
                    RecordingSettingsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DownScale = table.Column<float>(nullable: false),
                    MaxFPS = table.Column<int>(nullable: false),
                    PrototypeId = table.Column<int>(nullable: false),
                    WithFrontCamera = table.Column<bool>(nullable: false),
                    WithTouches = table.Column<bool>(nullable: false),
                    WithTouchesLogging = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrototypesSettings", x => x.RecordingSettingsId);
                    table.ForeignKey(
                        name: "FK_PrototypesSettings_Prototypes_PrototypeId",
                        column: x => x.PrototypeId,
                        principalTable: "Prototypes",
                        principalColumn: "PrototypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserPrototypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Biography = table.Column<string>(nullable: true),
                    LastRecordingDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PrototypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserPrototypeId);
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
                    RecordPrototypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PathToVideo = table.Column<string>(nullable: true),
                    UserPrototypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordsPrototype", x => x.RecordPrototypeId);
                    table.ForeignKey(
                        name: "FK_RecordsPrototype_Users_UserPrototypeId",
                        column: x => x.UserPrototypeId,
                        principalTable: "Users",
                        principalColumn: "UserPrototypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordsScreens",
                columns: table => new
                {
                    RecordsScreenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PathToHeatMapScreen = table.Column<string>(nullable: true),
                    PathToOriginalScreen = table.Column<string>(nullable: true),
                    PointsText = table.Column<string>(nullable: true),
                    RecordPrototypeId = table.Column<int>(nullable: false),
                    UriPage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordsScreens", x => x.RecordsScreenId);
                    table.ForeignKey(
                        name: "FK_RecordsScreens_RecordsPrototype_RecordPrototypeId",
                        column: x => x.RecordPrototypeId,
                        principalTable: "RecordsPrototype",
                        principalColumn: "RecordPrototypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrototypesSettings_PrototypeId",
                table: "PrototypesSettings",
                column: "PrototypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecordsPrototype_UserPrototypeId",
                table: "RecordsPrototype",
                column: "UserPrototypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordsScreens_RecordPrototypeId",
                table: "RecordsScreens",
                column: "RecordPrototypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrototypeId",
                table: "Users",
                column: "PrototypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrototypesSettings");

            migrationBuilder.DropTable(
                name: "RecordsScreens");

            migrationBuilder.DropTable(
                name: "RecordsPrototype");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Prototypes");
        }
    }
}
