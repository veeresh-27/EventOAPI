using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventOAPI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatTable",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatTable", x => x.ChatId);
                });

            migrationBuilder.CreateTable(
                name: "CommunityTable",
                columns: table => new
                {
                    CommunityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityCreatorUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityTable", x => x.CommunityId);
                });

            migrationBuilder.CreateTable(
                name: "EventTable",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTable", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_EventTable_CommunityTable_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "CommunityTable",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageTable",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityTableCommunityId = table.Column<int>(type: "int", nullable: true),
                    EventTableEventId = table.Column<int>(type: "int", nullable: true),
                    SpaceTableSapaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTable", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_ImageTable_CommunityTable_CommunityTableCommunityId",
                        column: x => x.CommunityTableCommunityId,
                        principalTable: "CommunityTable",
                        principalColumn: "CommunityId");
                    table.ForeignKey(
                        name: "FK_ImageTable_EventTable_EventTableEventId",
                        column: x => x.EventTableEventId,
                        principalTable: "EventTable",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateTable(
                name: "OwnerTable",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPicImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerTable", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_OwnerTable_ImageTable_OwnerPicImageId",
                        column: x => x.OwnerPicImageId,
                        principalTable: "ImageTable",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPicImageId = table.Column<int>(type: "int", nullable: false),
                    CommunityTableCommunityId = table.Column<int>(type: "int", nullable: true),
                    EventTableEventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserTable_CommunityTable_CommunityTableCommunityId",
                        column: x => x.CommunityTableCommunityId,
                        principalTable: "CommunityTable",
                        principalColumn: "CommunityId");
                    table.ForeignKey(
                        name: "FK_UserTable_EventTable_EventTableEventId",
                        column: x => x.EventTableEventId,
                        principalTable: "EventTable",
                        principalColumn: "EventId");
                    table.ForeignKey(
                        name: "FK_UserTable_ImageTable_UserPicImageId",
                        column: x => x.UserPicImageId,
                        principalTable: "ImageTable",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpaceTable",
                columns: table => new
                {
                    SapaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpaceLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceTable", x => x.SapaceId);
                    table.ForeignKey(
                        name: "FK_SpaceTable_OwnerTable_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "OwnerTable",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpaceTable_UserTable_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatTable_EventId",
                table: "ChatTable",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatTable_UserId",
                table: "ChatTable",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTable_CommunityCreatorUserId",
                table: "CommunityTable",
                column: "CommunityCreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTable_CommunityId",
                table: "EventTable",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTable_CreatorUserId",
                table: "EventTable",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTable_CommunityTableCommunityId",
                table: "ImageTable",
                column: "CommunityTableCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTable_EventTableEventId",
                table: "ImageTable",
                column: "EventTableEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTable_SpaceTableSapaceId",
                table: "ImageTable",
                column: "SpaceTableSapaceId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTable_OwnerPicImageId",
                table: "OwnerTable",
                column: "OwnerPicImageId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceTable_CreatorUserId",
                table: "SpaceTable",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceTable_OwnerId",
                table: "SpaceTable",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTable_CommunityTableCommunityId",
                table: "UserTable",
                column: "CommunityTableCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTable_EventTableEventId",
                table: "UserTable",
                column: "EventTableEventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTable_UserPicImageId",
                table: "UserTable",
                column: "UserPicImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatTable_EventTable_EventId",
                table: "ChatTable",
                column: "EventId",
                principalTable: "EventTable",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatTable_UserTable_UserId",
                table: "ChatTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityTable_UserTable_CommunityCreatorUserId",
                table: "CommunityTable",
                column: "CommunityCreatorUserId",
                principalTable: "UserTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventTable_UserTable_CreatorUserId",
                table: "EventTable",
                column: "CreatorUserId",
                principalTable: "UserTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageTable_SpaceTable_SpaceTableSapaceId",
                table: "ImageTable",
                column: "SpaceTableSapaceId",
                principalTable: "SpaceTable",
                principalColumn: "SapaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageTable_EventTable_EventTableEventId",
                table: "ImageTable");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTable_EventTable_EventTableEventId",
                table: "UserTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityTable_UserTable_CommunityCreatorUserId",
                table: "CommunityTable");

            migrationBuilder.DropForeignKey(
                name: "FK_SpaceTable_UserTable_CreatorUserId",
                table: "SpaceTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageTable_CommunityTable_CommunityTableCommunityId",
                table: "ImageTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageTable_SpaceTable_SpaceTableSapaceId",
                table: "ImageTable");

            migrationBuilder.DropTable(
                name: "ChatTable");

            migrationBuilder.DropTable(
                name: "EventTable");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropTable(
                name: "CommunityTable");

            migrationBuilder.DropTable(
                name: "SpaceTable");

            migrationBuilder.DropTable(
                name: "OwnerTable");

            migrationBuilder.DropTable(
                name: "ImageTable");
        }
    }
}
